namespace PatientlyService.Core.Requests;

public class CreateRoleRequest
{
    public string Name { get; set; }
    public ICollection<Guid> PermissionIds { get; set; }
}