using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Repositories;

public interface IUserRepository
{
    Task<bool> CreateAsync(User user, Guid sessionId, CancellationToken token = default);
}