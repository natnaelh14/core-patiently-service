namespace PatientlyService.Core.Models.User;

public class Permission
{
    public Guid Id;
    public String PermissionCode;
    public String DisplayName;
    public String Description;
    public String Category;
    public Boolean IsEnabled;
}