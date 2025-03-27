
using PatientlyService.Core.Models.Tenant;

namespace PatientlyService.Core.Repositories;

public interface ITenantRepository
{
    Task<bool> CreateAsync(Tenant tenant, CancellationToken token = default);
    // Task<IEnumerable<Tenant>> GetAllAsync(GetAllTenantsOptions options, CancellationToken token = default);
}


