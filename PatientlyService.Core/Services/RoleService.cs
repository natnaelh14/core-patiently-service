using PatientlyService.Core.Models.User;
using PatientlyService.Core.Repositories;
using FluentValidation;

namespace PatientlyService.Core.Services;

public class RoleService: IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IValidator<Role> _roleValidator;


    public RoleService(IRoleRepository roleRepository, IValidator<Role> roleValidator)
    {
        _roleRepository = roleRepository;
        _roleValidator = roleValidator;

    }

    public async Task<bool> CreateAsync(Role role, CancellationToken token = default)
    {
        return await _roleRepository.CreateAsync(role, token);
    }

    // public async Task<IEnumerable<Role>> GetAllAsync(CancellationToken token = default)
    // {
    //     return await _roleRepository.GetAllAsync(token);
    // }
    //
    // public async Task<Role?> GetByIdAsync(Guid id, CancellationToken token = default)
    // {
    //     return await _roleRepository.GetByIdAsync(id, token);
    // }
}