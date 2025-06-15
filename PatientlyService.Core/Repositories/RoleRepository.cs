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
    
    public async Task<IEnumerable<Role>> GetAllAsync(CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var sql = """
                  SELECT
                      r.Id AS RoleId, r.Name,
                      rp.PermissionId
                  FROM Roles AS r
                  LEFT JOIN RolePermissions AS rp ON r.Id = rp.RoleId
                  ORDER BY r.Name;
                  """;

        var roleDict = new Dictionary<Guid, Role>();

        await connection.QueryAsync<Guid, Guid?, Role>(
            new CommandDefinition(sql, cancellationToken: token),
            (roleId, permissionId) =>
            {
                if (!roleDict.TryGetValue(roleId, out var role))
                {
                    role = new Role
                    {
                        Id = roleId,
                        Name = "", // optionally set later or join it in the SELECT
                        PermissionIds = new List<Guid>()
                    };
                    roleDict.Add(roleId, role);
                }

                if (permissionId.HasValue)
                    role.PermissionIds.Add(permissionId.Value);

                return role;
            },
            splitOn: "PermissionId"
        );

        // Optional: query role names in a separate query or include it in the mapping above

        return roleDict.Values;
    }
    public async Task<Role?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);

        var sql = """
                  SELECT
                      r.Id AS RoleId, r.Name,
                      rp.PermissionId
                  FROM Roles AS r
                  LEFT JOIN RolePermissions AS rp ON r.Id = rp.RoleId
                  WHERE r.Id = @Id;
                  """;

        Role? role = null;

        await connection.QueryAsync<Guid, Guid?, Role>(
            new CommandDefinition(sql, new { Id = id }, cancellationToken: token),
            (roleId, permissionId) =>
            {
                if (role == null)
                {
                    role = new Role
                    {
                        Id = roleId,
                        Name = "", // If you need the name, add to SELECT
                        PermissionIds = new List<Guid>()
                    };
                }

                if (permissionId.HasValue)
                    role.PermissionIds.Add(permissionId.Value);

                return role;
            },
            splitOn: "PermissionId"
        );

        return role;
    }
}