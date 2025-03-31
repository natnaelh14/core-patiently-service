using PatientlyService.Core.Models.User;
using FluentValidation;
using PatientlyService.Core.Repositories;
namespace PatientlyService.Core.Validators;

public class UserInviteValidator : AbstractValidator<UserInvite>
{
    private readonly IUserInviteRepository _userInviteRepository;
    
    public UserInviteValidator(IUserInviteRepository userInviteRepository)
    {
        _userInviteRepository = userInviteRepository;
        RuleFor(x => x.TenantId)
            .NotEmpty();
        RuleFor(x => x.RoleId)
            .NotEmpty();
        RuleFor(x => x.UserType)
            .NotEmpty();
        RuleFor(x => x.Prefix)
            .NotEmpty();
        RuleFor(x => x.FirstName)
            .NotEmpty();
        RuleFor(x => x.Email)
            .NotEmpty();
    }
}