using PatientlyService.Core.Models.User;
using FluentValidation;
using PatientlyService.Core.Repositories;

namespace PatientlyService.Core.Validators;

public class PermissionValidator: AbstractValidator<Permission>
{
    private readonly IPermissionRepository _permissionRepository;
    public PermissionValidator(IPermissionRepository permissionRepository)
    {
        _permissionRepository = permissionRepository;
        RuleFor(x => x.Id)
            .NotEmpty();
        RuleFor(x => x.PermissionCode)
            .NotEmpty();
        RuleFor(x => x.DisplayName)
            .NotEmpty();
        RuleFor(x => x.Description)
            .NotEmpty();
        RuleFor(x => x.Category)
            .NotEmpty();
        RuleFor(x => x.IsEnabled)
            .NotEmpty();
    }
}