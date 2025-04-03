using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Requests;

public class UserInviteRequest
{
    public required Guid tenantId { get; init; }

    public required UserType userType { get; init; }

    public required Guid roleId { get; init; }

    public required String prefix { get; init; }

    public required String firstName { get; init; }

    public required String email { get; init; }

}