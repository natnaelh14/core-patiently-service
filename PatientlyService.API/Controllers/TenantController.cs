using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientlyService.Core.Repositories;

namespace PatientlyService.API.Controllers;

public class TenantController: ControllerBase
{
    private readonly IMapper mapper;
    private readonly ITenantRepository tenantRepository;
}