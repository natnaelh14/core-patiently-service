using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Responses;

public class UserInviteResponse
{
    public Guid Id { get; init; }
    
    public Guid TenantId { get; init; }

    public UserType UserType { get; init; }

    public Guid RoleId { get; init; }

    public String Prefix { get; init; }

    public String FirstName { get; init; }

    public String Email { get; init; }
}