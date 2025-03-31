using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Requests;

public class UserInviteRequest
{
    public Guid tenantId;

    public UserType userType;

    public Guid roleId;

    public String prefix;

    public String firstName;

    public String email;
}