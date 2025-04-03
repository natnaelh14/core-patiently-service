namespace PatientlyService.Core.Models.User;

public partial class UserInvite {
    public Guid Id;

    public Guid TenantId;

    public Guid RoleId;
    
    public UserType UserType;
    
    public String Prefix;

    public String FirstName;

    public String Email;
}
