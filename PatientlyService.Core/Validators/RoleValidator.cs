using PatientlyService.Core.Models.User;
using FluentValidation;
using PatientlyService.Core.Repositories;

namespace PatientlyService.Core.Validators;

public class RoleValidator: AbstractValidator<Role>
{
    private readonly IRoleRepository _roleRepository;
    public RoleValidator(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
        RuleFor(x => x.Id)
            .NotEmpty();
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.PermissionIds)
            .NotEmpty()
            .WithMessage("At least one permission must be assigned.");

    }
}