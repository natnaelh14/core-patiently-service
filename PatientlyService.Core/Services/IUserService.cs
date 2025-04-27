using PatientlyService.Core.Models.Auth;
using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Services;

public interface IUserService
{
    Task<bool> RegistrationAsync(User user, RegistrationType registrationType, Guid? userId, Guid sessionId, CancellationToken token = default);
}