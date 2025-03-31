using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientlyService.Api.Auth;
using PatientlyService.API.Mapping; 
using PatientlyService.Core.Services;
using PatientlyService.Core.Responses;
using PatientlyService.Core.Requests;

namespace PatientlyService.API.Controllers;

[ApiController]
[ApiVersion(1.0)]
public class TenantController: ControllerBase
{
    private readonly ITenantService _tenantService;
    public TenantController(ITenantService tenantService)
    {
        _tenantService = tenantService;
    }
    // [Authorize(AuthConstants.TrustedMemberPolicyName)]
    [HttpPost(ApiEndpoints.Tenant.Create)]
    [ProducesResponseType(typeof(TenantResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody]CreateTenantRequest request,
        CancellationToken token)
    {
        var tenant = request.MapToTenant();
        await _tenantService.CreateAsync(tenant, token);
        var tenantResponse = tenant.MapToResponse();
        return Ok(tenantResponse);
    }
    
    [HttpGet(ApiEndpoints.Tenant.GetAll)]
    [ProducesResponseType(typeof(TenantsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll(
        [FromQuery] GetAllTenantsRequest request, CancellationToken token)
    {
        var options = request.MapToOptions();
        var tenant = await _tenantService.GetAllAsync(options, token);
        var moviesResponse = tenant.MapToResponse();
        return Ok(moviesResponse);
    }
    
    [HttpPut(ApiEndpoints.Tenant.Update)]
    [ProducesResponseType(typeof(TenantResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromRoute]Guid id,
        [FromBody]UpdateTenantRequest request,
        CancellationToken token)
    {
        var movie = request.MapToTenant(id);
        var updatedMovie = await _tenantService.UpdateAsync(movie, token);
        if (updatedMovie is null)
        {
            return NotFound();
        }
        var response = updatedMovie.MapToResponse();
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Tenant.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id,
        CancellationToken token)
    {
        var deleted = await _tenantService.DeleteByIdAsync(id, token);
        if (!deleted)
        {
            return NotFound();
        }
        return Ok();
    }
}