using FluentValidation;
using PatientlyService.Core.Models.Tenant;
using PatientlyService.Core.Repositories;

namespace PatientlyService.Core.Validators;

public class TenantValidator : AbstractValidator<Tenant>
{
    private readonly ITenantRepository _tenantRepository;
    
    public TenantValidator(ITenantRepository tenantRepository)
    {
        _tenantRepository = tenantRepository;
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.StreetAddress)
            .NotEmpty();

        RuleFor(x => x.City)
            .NotEmpty();

        RuleFor(x => x.State)
            .NotEmpty();
        
        RuleFor(x => x.ZipCode)
            .NotEmpty();
        
        RuleFor(x => x.Country)
            .NotEmpty();
        
        RuleFor(x => x.PictureUrl)
            .NotEmpty();
    }
}