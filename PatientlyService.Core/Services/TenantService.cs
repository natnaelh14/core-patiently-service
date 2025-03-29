using FluentValidation;
using PatientlyService.Core.Models.Tenant;
using PatientlyService.Core.Repositories;

namespace PatientlyService.Core.Services;

public class TenantService : ITenantService
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IValidator<Tenant> _tenantValidator;
    private readonly IValidator<GetAllTenantsOptions> _optionsValidator;


    public TenantService(ITenantRepository tenantRepository, IValidator<Tenant> tenantValidator, IValidator<GetAllTenantsOptions> optionsValidator)
    {
        _tenantRepository = tenantRepository;
        _tenantValidator = tenantValidator;
        _optionsValidator = optionsValidator;
    }

    public async Task<bool> CreateAsync(Tenant tenant, CancellationToken token = default)
    {
        await _tenantValidator.ValidateAndThrowAsync(tenant, cancellationToken: token);
        return await _tenantRepository.CreateAsync(tenant, token);
    }
    public async Task<IEnumerable<Tenant>> GetAllAsync(GetAllTenantsOptions options, CancellationToken token = default)
    {
        await _optionsValidator.ValidateAndThrowAsync(options, token);
        return await _tenantRepository.GetAllAsync(options, token);
    }
    public async Task<Tenant?> UpdateAsync(Tenant tenant, CancellationToken token = default)
    {
        await _tenantValidator.ValidateAndThrowAsync(tenant, cancellationToken: token);
        var movieExists = await _tenantRepository.ExistsByIdAsync(tenant.Id, token);
        if (!movieExists)
        {
            return null;
        }
        await _tenantRepository.UpdateAsync(tenant, token);
        return tenant;
    }

    public Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        return _tenantRepository.DeleteByIdAsync(id, token);
    }
}
