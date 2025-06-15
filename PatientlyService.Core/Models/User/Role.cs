namespace PatientlyService.Core.Models.User;

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Guid> PermissionIds { get; set; }
}