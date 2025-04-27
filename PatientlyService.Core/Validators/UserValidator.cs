using PatientlyService.Core.Models.User;
using FluentValidation;
using PatientlyService.Core.Repositories;

namespace PatientlyService.Core.Validators;

public class UserValidator: AbstractValidator<User>
{
    private readonly IUserRepository _userRepository;
    public UserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        RuleFor(x => x.Id)
            .NotEmpty();
        RuleFor(x => x.Email)
            .NotEmpty();
        RuleFor(x => x.Password)
            .NotEmpty();
        RuleFor(x => x.PictureUrl)
            .NotEmpty();
        RuleFor(x => x.RoleId)
            .NotEmpty();
        RuleFor(x => x.Status)
            .NotEmpty();
        RuleFor(x => x.UserType)
            .NotEmpty();
        RuleFor(x => x.FirstName)
            .NotEmpty();
        RuleFor(x => x.MiddleName)
            .NotEmpty();
        RuleFor(x => x.LastName)
            .NotEmpty();
        RuleFor(x => x.PhoneNumber)
            .NotEmpty();
        RuleFor(x => x.DOB)
            .NotEmpty();
        RuleFor(x => x.Gender)
            .NotEmpty();
    }
}