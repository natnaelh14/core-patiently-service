using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using PatientlyService.Core.Requests;
using PatientlyService.Core.Services;
using PatientlyService.API.Mapping;
using PatientlyService.Core.Models.Auth;
using PatientlyService.Core.Responses;

namespace PatientlyService.API.Controllers;

[ApiController]
[ApiVersion(1.0)]
public class UserController: ControllerBase
{
    private readonly IUserInviteService _userInviteService;
    private readonly IUserService _userService;
    public UserController(IUserInviteService userInviteService, IUserService userService)
    {
        _userInviteService = userInviteService;
        _userService = userService;
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
        return CreatedAtAction(nameof(Invite), new { id = inviteResponse.Id }, inviteResponse);
    }
    
    [HttpGet(ApiEndpoints.User.GetSession)]
    [ProducesResponseType(typeof(UserInviteResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSession([FromRoute] string id,
        CancellationToken token)
    {
        var session = Guid.TryParse(id, out var paramId) ? await _userInviteService.GetSessionByIdAsync(paramId, token) : null;
        if (session is null)
        {
            return NotFound();
        }
        var response = session.MapToResponse();
        return Ok(response);
    }
    
    [HttpPost(ApiEndpoints.User.Signup)]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignUp([FromBody]UserRequest request, [FromRoute] Guid sessionId,
        CancellationToken token)
    { 
        var user = request.MapToUser();
        await _userService.RegistrationAsync(user, RegistrationType.SIGNUP, null,sessionId, token);
        var userResponse = user.MapToResponse();
        return CreatedAtAction(nameof(SignUp), new { id = userResponse.Id }, userResponse);
    }
}