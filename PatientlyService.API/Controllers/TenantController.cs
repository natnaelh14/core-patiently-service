using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientlyService.Api.Auth;
using PatientlyService.API.Mapping; 
using PatientlyService.Core.Services;
using PatientlyService.Contract.Responses;
using PatientlyService.Contract.Requests;

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

}