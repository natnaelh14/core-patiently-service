using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Repositories;

public interface IPermissionRepository
{
    Task<bool> CreateAsync(Permission permission, CancellationToken token = default);
    Task<IEnumerable<Permission>> GetAllAsync(CancellationToken token = default);
    Task<Permission?> GetByIdAsync(Guid id, CancellationToken token = default);
}