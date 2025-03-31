
using FluentValidation;
using PatientlyService.Core.Models.User;
using PatientlyService.Core.Repositories;

namespace PatientlyService.Core.Services;

public class UserInviteService : IUserInviteService
{
    private readonly IUserInviteRepository _userInviteRepository;
    private readonly IValidator<UserInvite> _userInviteValidator;


    public UserInviteService(IUserInviteRepository userInviteRepository, IValidator<UserInvite> userInviteValidator)
    {
        _userInviteRepository = userInviteRepository;
        _userInviteValidator = userInviteValidator;
    }

    public async Task<bool> CreateAsync(UserInvite userInvite, CancellationToken token = default)
    {
        await _userInviteValidator.ValidateAndThrowAsync(userInvite, cancellationToken: token);
        return await _userInviteRepository.InviteAsync(userInvite, token);
    }
}
