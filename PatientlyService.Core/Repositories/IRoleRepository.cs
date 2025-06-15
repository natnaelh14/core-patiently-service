using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Repositories;

public interface IRoleRepository
{
    Task<bool> CreateAsync(Role role, CancellationToken token = default);
    // Task<IEnumerable<Role>> GetAllAsync(CancellationToken token = default);
    // Task<Role?> GetByIdAsync(Guid id, CancellationToken token = default);
}