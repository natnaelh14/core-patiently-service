using PatientlyService.Core.Models;
using PatientlyService.Core.Models.Tenant;

namespace PatientlyService.Core.Services;

public interface ITenantService
{
    Task<bool> CreateAsync(Tenant tenant, CancellationToken token = default);
    Task<IEnumerable<Tenant>> GetAllAsync(GetAllTenantsOptions options, CancellationToken token = default);
    Task<Tenant?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<Tenant?> UpdateAsync(Tenant tenant, CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);

}