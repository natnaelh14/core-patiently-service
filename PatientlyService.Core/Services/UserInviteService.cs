
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

    public async Task<bool> InviteAsync(UserInvite userInvite, CancellationToken token = default)
    {
        await _userInviteValidator.ValidateAndThrowAsync(userInvite, cancellationToken: token);
        return await _userInviteRepository.InviteAsync(userInvite, token);
    }
    
    public async Task<UserInvite> GetSessionByIdAsync(Guid id, CancellationToken token = default)
    {
        var result = await _userInviteRepository.GetSessionByIdAsync(id, token);
        if (result == null)
        {
            throw new KeyNotFoundException($"User invite with ID {id} not found.");
        }
        return result;
    }
}
