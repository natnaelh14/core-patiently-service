using FluentValidation;
using PatientlyService.Core.Models.User;
using PatientlyService.Core.Repositories;
using PatientlyService.Core.Models.Auth;

namespace PatientlyService.Core.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IValidator<User> _userValidator;
    
    public UserService(IUserRepository userRepository, IValidator<User> userValidator)
    {
        _userRepository = userRepository;
        _userValidator = userValidator;
    }
    public async Task<bool> RegistrationAsync(User user, RegistrationType registrationType, Guid? userId, Guid sessionId, CancellationToken token = default)
    {
        await _userValidator.ValidateAndThrowAsync( user, cancellationToken: token);
        return await _userRepository.CreateAsync(user, sessionId, token);
    }
}