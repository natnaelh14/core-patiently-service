using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using PatientlyService.API.Mapping;
using PatientlyService.Core.Services;
using PatientlyService.Core.Responses;
using PatientlyService.Core.Requests;

namespace PatientlyService.API.Controllers;

[ApiController]
[ApiVersion(1.0)]
public class PermissionController: ControllerBase
{
    private readonly IPermissionService _permissionService;
    public PermissionController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }
    
    [HttpPost(ApiEndpoints.Permission.Create)]
    [ProducesResponseType(typeof(PermissionResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody]CreatePermissionRequest request,
        CancellationToken token)
    {
        var permission = request.MapToPermission();
        await _permissionService.CreateAsync(permission, token);
        var permissionResponse = permission.MapToResponse();
        return CreatedAtAction(nameof(Create), new { id = permissionResponse.Id }, permissionResponse);
    }
    
    [HttpGet(ApiEndpoints.Permission.Get)]
    [ProducesResponseType(typeof(PermissionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
    {
        var permission = await _permissionService.GetByIdAsync(id, token);
        if (permission is null)
        {
            return NotFound();
        }
        var permissionResponse = permission.MapToResponse();
        return Ok(permissionResponse);
    }
    
    [HttpGet(ApiEndpoints.Permission.GetAll)]
    [ProducesResponseType(typeof(IEnumerable<PermissionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var permissions = await _permissionService.GetAllAsync(token);
        var permissionResponses = permissions.Select(p => p.MapToResponse());
        return Ok(permissionResponses);
    }
};

