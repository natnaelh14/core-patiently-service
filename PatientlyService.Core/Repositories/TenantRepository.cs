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
        var sql = @"
        INSERT INTO tenants (
            id, name, streetaddress, city, state, country, zipcode, pictureurl
        ) VALUES (
            @Id, @Name, @StreetAddress, @City, @State, @Country, @ZipCode, @PictureUrl
        )";
    
        var result = await connection.ExecuteAsync(
            new CommandDefinition(
                sql, 
                new {
                    tenant.Id, 
                    tenant.Name, 
                    tenant.StreetAddress, 
                    tenant.City, 
                    tenant.State, 
                    tenant.Country, 
                    tenant.ZipCode, 
                    tenant.PictureUrl
                }, 
                cancellationToken: token)
        );
        return result > 0;
    }
}
