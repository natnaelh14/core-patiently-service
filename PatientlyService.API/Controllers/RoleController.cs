using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using PatientlyService.API.Mapping;
using PatientlyService.Core.Services;
using PatientlyService.Core.Responses;
using PatientlyService.Core.Requests;

namespace PatientlyService.API.Controllers;

[ApiController]
[ApiVersion(1.0)]
public class RoleController: ControllerBase
{
    private readonly IRoleService _roleService;
    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    
    [HttpPost(ApiEndpoints.Role.Create)]
    [ProducesResponseType(typeof(RoleResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody]CreateRoleRequest request,
        CancellationToken token)
    {
        var role = request.MapToRole();
        await _roleService.CreateAsync(role, token);
        var roleResponse = role.MapToResponse();
        return CreatedAtAction(nameof(Create), new { id = roleResponse.Id }, roleResponse);
    }
}