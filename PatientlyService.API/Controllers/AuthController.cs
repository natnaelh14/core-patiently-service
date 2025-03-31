using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using PatientlyService.Core.Services;
using PatientlyService.Core.Responses;

namespace PatientlyService.API.Controllers;

[ApiController]
[ApiVersion(1.0)]
public class AuthController: ControllerBase
{
    // private readonly IAuthService _authService;
    // public AuthController(IAuthService authService)
    // {
    //     _authService = authService;
    // }
    // [HttpPost(ApiEndpoints.Patient.StartRegistration)]
    // [ProducesResponseType(typeof(PatientRegistrationResponse), StatusCodes.Status201Created)]
    // [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
    // public async Task<IActionResult> StartRegistration([FromBody]CreateTenantRequest request,
    //     CancellationToken token)
    // {
    //     var tenant = request.MapToTenant();
    //     await _authService.StartRegistrationAsync(tenant, token);
    //     var tenantResponse = tenant.MapToResponse();
    //     return Ok(tenantResponse);
    // }
}