using Dapper;
using PatientlyService.Core.Database;
using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Repositories;

public class UserInviteRepository : IUserInviteRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;
    public UserInviteRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }
    public async Task<bool> InviteAsync(UserInvite userInvite, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        var sql = @"
        INSERT INTO sessions (
            id, tenantid, roleid, usertype, prefix, firstname, email
        ) VALUES (
            @Id, @TenantId, @RoleId, @UserType, @Prefix, @FirstName, @Email
        )";

        var result = await connection.ExecuteAsync(
            new CommandDefinition(
                sql,
                new
                {
                    userInvite.Id,
                    userInvite.TenantId,
                    userInvite.RoleId,
                    userInvite.UserType,
                    userInvite.Prefix,
                    userInvite.FirstName,
                    userInvite.Email
                },
                cancellationToken: token)
        );
        return result > 0;
    }
    
    public async Task<UserInvite?> GetSessionByIdAsync(Guid id, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        const string sql = @"
        SELECT * 
        FROM sessions 
        WHERE id = @Id";
        
        var result = await connection.QuerySingleOrDefaultAsync<UserInvite>(
            new CommandDefinition(
                sql,
                new { Id = id },
                cancellationToken: token)
        );
        return result;
    }
}