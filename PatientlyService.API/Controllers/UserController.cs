using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using PatientlyService.Core.Requests;
using PatientlyService.Core.Services;
using PatientlyService.API.Mapping; 
using PatientlyService.Core.Responses;

namespace PatientlyService.API.Controllers;

[ApiController]
[ApiVersion(1.0)]
public class UserController: ControllerBase
{
    private readonly IUserInviteService _userInviteService;
    public UserController(IUserInviteService userInviteService)
    {
        _userInviteService = userInviteService;
    }
    
    [HttpPost(ApiEndpoints.User.Invite)]
    [ProducesResponseType(typeof(UserInviteResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Invite([FromBody]UserInviteRequest request,
        CancellationToken token)
    {
        var invite = request.MapToUserInvite();
        await _userInviteService.InviteAsync(invite, token);
        var inviteResponse = invite.MapToResponse();
        return Ok(inviteResponse);
    }
}