using Dapper;
using PatientlyService.Core.Database;
using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Repositories;

public class PermissionRepository: IPermissionRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public PermissionRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    public async Task<bool> CreateAsync(Permission permission, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        var sql = @"
        INSERT INTO permissions (
            id, permission_code, display_name, description, category, is_enabled
        ) VALUES (
            @Id, @PermissionCode, @DisplayName, @Description, @Category, @IsEnabled
        )";

        var result = await connection.ExecuteAsync(
            new CommandDefinition(
                sql,
                new
                {
                    permission.Id,
                    permission.PermissionCode,
                    permission.Description,
                    permission.Category,
                    permission.IsEnabled
                },
                cancellationToken: token)
        );
        return result > 0;
    }
    public async Task<IEnumerable<Permission>> GetAllAsync(CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var query = $"""
                     SELECT * 
                     FROM permissions 
                     """;

        return await connection.QueryAsync<Permission>(new CommandDefinition(query, cancellationToken: token));;
    }
    public async Task<Permission?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        var query = """
                    SELECT * 
                    FROM permissions 
                    WHERE Id = @Id
                    """;
        return await connection.QuerySingleOrDefaultAsync<Permission>(
            new CommandDefinition(query, new { Id = id }, cancellationToken: token));
    }
}