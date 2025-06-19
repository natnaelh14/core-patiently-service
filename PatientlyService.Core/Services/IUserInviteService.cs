using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Services;

public interface IUserInviteService
{
    Task<bool> InviteAsync(UserInvite userInvite, CancellationToken token = default);
    Task<UserInvite> GetSessionByIdAsync(Guid id, CancellationToken token = default);
}