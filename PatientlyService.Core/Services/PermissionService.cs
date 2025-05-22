using PatientlyService.Core.Models.User;
using PatientlyService.Core.Repositories;
using FluentValidation;

namespace PatientlyService.Core.Services;

public class PermissionService: IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;
    private readonly IValidator<Permission> _permissionValidator;


    public PermissionService(IPermissionRepository permissionRepository, IValidator<Permission> permissionValidator)
    {
        _permissionRepository = permissionRepository;
        _permissionValidator = permissionValidator;

    }

    public async Task<bool> CreateAsync(Permission permission, CancellationToken token = default)
    {
        return await _permissionRepository.CreateAsync(permission, token);
    }

    public async Task<IEnumerable<Permission>> GetAllAsync(CancellationToken token = default)
    {
        return await _permissionRepository.GetAllAsync(token);
    }

    public async Task<Permission?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _permissionRepository.GetByIdAsync(id, token);
    }
}