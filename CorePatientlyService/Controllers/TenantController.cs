using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CorePatientlyService.Repositories;

namespace CorePatientlyService.Controllers;

public class TenantController: ControllerBase
{
    private readonly IMapper mapper;
    private readonly ITenantRepository tenantRepository;
}