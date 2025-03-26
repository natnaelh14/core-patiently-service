using FluentValidation;
using PatientlyService.Core.Models.Tenant;
using PatientlyService.Core.Repositories;

namespace PatientlyService.Core.Services;

public class TenantService : ITenantService
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IValidator<Tenant> _tenantValidator;

    public TenantService(ITenantRepository tenantRepository, IValidator<Tenant> tenantValidator)
    {
        _tenantRepository = tenantRepository;
        _tenantValidator = tenantValidator;
    }

    public async Task<bool> CreateAsync(Tenant tenant, CancellationToken token = default)
    {
        await _tenantValidator.ValidateAndThrowAsync(tenant, cancellationToken: token);
        return await _tenantRepository.CreateAsync(tenant, token);
    }
    
}
