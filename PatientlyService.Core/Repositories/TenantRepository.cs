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
                new
                {
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
    public async Task<IEnumerable<Tenant>> GetAllAsync(GetAllTenantsOptions options, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var orderClause = string.Empty;
        if (!string.IsNullOrWhiteSpace(options.SortField))
        {
            orderClause = $"""
                           ORDER BY {options.SortField} {(options.SortOrder == SortOrder.Ascending ? "ASC" : "DESC")}
                           """;
        }

        var query = $"""
                     SELECT * 
                     FROM tenants 
                     {orderClause}
                     """;

        return await connection.QueryAsync<Tenant>(new CommandDefinition(query, cancellationToken: token));;
    }
    public async Task<bool> UpdateAsync(Tenant tenant, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
    
        var sql = @"
        UPDATE tenants
        SET name = @Name,
            streetaddress = @StreetAddress,
            city = @City,
            state = @State,
            country = @Country,
            zipcode = @ZipCode,
            pictureurl = @PictureUrl
        WHERE id = @Id
    ";
    
        var result = await connection.ExecuteAsync(
            new CommandDefinition(
                sql,
                new
                {
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
    public async Task<bool> DeleteByIdAsync(Guid tenantId, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
    
        var sql = "DELETE FROM tenants WHERE id = @Id";
    
        var result = await connection.ExecuteAsync(
            new CommandDefinition(
                sql,
                new { Id = tenantId },
                cancellationToken: token)
        );
    
        return result > 0;
    }
    public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        return await connection.ExecuteScalarAsync<bool>(new CommandDefinition("""
           select count(1) from tenants where id = @id
           """, new { id }, cancellationToken: token));
    }
}