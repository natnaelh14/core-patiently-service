namespace PatientlyService.Core.Models.User;

public class UserInvite {

    public Guid TenantId;

    public Guid RoleId;
    
    public UserType UserType;
    
    public String Prefix;

    public String FirstName;

    public String Email;
}
