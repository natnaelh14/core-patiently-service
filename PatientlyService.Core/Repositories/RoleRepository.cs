using Dapper;
using PatientlyService.Core.Database;
using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Repositories;

public class RoleRepository: IRoleRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public RoleRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    public async Task<bool> CreateAsync(Role role, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        const string roleSql = @"
        INSERT INTO roles (
            id, name
        ) VALUES (
            @Id, @Name
        )";
        var roleInsertResult = await connection.ExecuteAsync(
            new CommandDefinition(
                roleSql,
                new { role.Id, role.Name },
                cancellationToken: token
            )
        );
        if (roleInsertResult == 0)
            return false;
        if (role.PermissionIds?.Any() == true)
        {
            const string rolePermissionsSql = @"
            INSERT INTO rolepermissions (
                RoleId, PermissionId
            ) VALUES (
                @RoleId, @PermissionId
            )";
            var rolePermissionParams = role.PermissionIds.Select(permissionId => new
            {
                RoleId = role.Id,
                PermissionId = permissionId
            });
            await connection.ExecuteAsync(
                new CommandDefinition(
                    rolePermissionsSql,
                    rolePermissionParams,
                    cancellationToken: token
                )
            );
        }

        return true;
    }
    
    // public async Task<IEnumerable<Role>> GetAllAsync(CancellationToken token = default)
    // {
    //    using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
    //
    //     // SQL query to join Roles, RolePermissions, and Permissions tables.
    //     // We select all columns from Roles (r.*) and specific columns from Permissions (p.Id, p.PermissionCode, etc.).
    //     // IMPORTANT: The 'Id' column from the Permission table MUST appear AFTER all Role columns
    //     // in the SELECT list, as it's used by Dapper's 'splitOn' parameter.
    //     var sql = """
    //         SELECT
    //             r.Id, r.Name, r.CreatedDate, r.UpdatedDate, -- All Role columns
    //             p.Id, p.PermissionCode, p.Description, p.CreatedDate AS PermissionCreatedDate, p.UpdatedDate AS PermissionUpdatedDate -- Permission columns
    //         FROM Roles AS r
    //         LEFT JOIN RolePermissions AS rp ON r.Id = rp.RoleId
    //         LEFT JOIN Permissions AS p ON rp.PermissionId = p.Id
    //         ORDER BY r.Name, p.PermissionCode;
    //         """;
    //     var roleDictionary = new Dictionary<Guid, Role>();
    //     await connection.QueryAsync<Role, Permission, Role>(
    //         new CommandDefinition(
    //             sql,
    //             cancellationToken: token
    //         ),
    //         (role, permission) => // This lambda is executed for each row returned by the query
    //         {
    //             // Try to get the role from our dictionary. If it's the first time we've seen this role, add it.
    //             if (!roleDictionary.TryGetValue(role.Id, out var currentRole))
    //             {
    //                 currentRole = role;
    //                 // Initialize the Permissions collection to avoid null reference exceptions
    //                 currentRole.Permissions = new List<Permission>();
    //                 roleDictionary.Add(currentRole.Id, currentRole);
    //             }
    //
    //             // If a permission exists for this row (i.e., it wasn't a LEFT JOIN where no permission matched)
    //             if (permission != null)
    //             {
    //                 // Add the permission to the role's collection if it hasn't been added already
    //                 // This check prevents duplicate permissions if a complex join might return them.
    //                 if (!currentRole.Permissions.Any(p => p.Id == permission.Id))
    //                 {
    //                     currentRole.Permissions.Add(permission);
    //                 }
    //             }
    //
    //             return currentRole; // Dapper's multi-map still needs a return, even if we're building externally
    //         },
    //         splitOn: "Id" // This must be the name of the column where the second object (Permission) starts in your SELECT statement.
    //     );
    //
    //     return roleDictionary.Values; // Return all unique roles with their populated permissions
    // }
    // public async Task<Role?> GetByIdAsync(Guid id, CancellationToken token = default)
    // {
    //     using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
    //     var query = """
    //                 SELECT * 
    //                 FROM roles 
    //                 WHERE Id = @Id
    //                 """;
    //     return await connection.QuerySingleOrDefaultAsync<Role>(
    //         new CommandDefinition(query, new { Id = id }, cancellationToken: token));
    // }
}