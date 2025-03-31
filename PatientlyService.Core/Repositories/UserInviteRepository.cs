using Dapper;
using PatientlyService.Core.Database;
using PatientlyService.Core.Database;

namespace PatientlyService.Core.Repositories;

public class UserInviteRepository : IUserInviteRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public UserInviteRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<bool> InviteAsync(CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        return true;
    }
}