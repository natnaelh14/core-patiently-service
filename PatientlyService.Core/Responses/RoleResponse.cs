using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Responses;

public class RoleResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Guid> PermissionIds { get; set; }
}