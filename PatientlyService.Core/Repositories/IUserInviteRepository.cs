using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Repositories;

public interface IUserInviteRepository
{
    Task<bool> InviteAsync (UserInvite userInvite, CancellationToken token = default);
    Task<UserInvite?> GetSessionByIdAsync(Guid id, CancellationToken token = default);

}

