
using PatientlyService.Core.Models.Tenant;

namespace PatientlyService.Core.Repositories;

public interface ITenantRepository
{
    Task<bool> CreateAsync(Tenant tenant, CancellationToken token = default);
    Task<IEnumerable<Tenant>> GetAllAsync(GetAllTenantsOptions options, CancellationToken token = default);
    Task<Tenant?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<bool> UpdateAsync(Tenant tenant, CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
    Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default);

}


