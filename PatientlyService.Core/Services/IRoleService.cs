using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Services;

public interface IRoleService
{
    Task<bool> CreateAsync(Role role, CancellationToken token = default);
    // Task<IEnumerable<Role>> GetAllAsync(CancellationToken token = default);
    // Task<Role?> GetByIdAsync(Guid id, CancellationToken token = default);
}