using Dapper;
using PatientlyService.Core.Database;
using PatientlyService.Core.Models.Tenant;

namespace PatientlyService.Core.Repositories;

public class TenantRepository : ITenantRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public TenantRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<bool> CreateAsync(Tenant tenant, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        using var transaction = connection.BeginTransaction();
        
        var result = await connection.ExecuteAsync(new CommandDefinition("""
            insert into tenant (id, name, streetaddress, city, state, zipcode, country, pictureurl) 
            values (@Id, @Name, @StreetAddress, @City, @State, @ZipCode, @Country, @PictureUrl)
            """, tenant, cancellationToken: token));
        
        return result > 0;
    }



    public async Task<IEnumerable<Tenant>> GetAllAsync(GetAllTenantsOptions options, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var orderClause = string.Empty;
        if (options.SortField is not null)
        {
            orderClause = $"""
            , m.{options.SortField}
            order by m.{options.SortField} {(options.SortOrder == SortOrder.Ascending ? "asc" : "desc" )}
            """;
        }
        
        var result = await connection.QueryAsync(new CommandDefinition($"""
            select t.*, 
            from tenant t 
            """, new
        {
        }, cancellationToken: token));
        
        return result.Select(x => new Tenant
        {
            Id = x.id,
            Name = x.title,
            StreetAddress = x.streetAddress,
            City = x.city,
            State = x.state,
            ZipCode = x.zipCode,
            Country = x.country,
            PictureUrl = x.pictureUrl,
        });
    }
    
}
