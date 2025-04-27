using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Requests;

public class UserRequest
{
    public required String email { get; init; }
    public required String password { get; init; }
    public required String pictureUrl { get; init; }
    public required Guid roleId { get; init; }
    public required Status status { get; init; }
    public required UserType userType { get; init; }
    public required String firstName { get; init; }
    public required String middleName { get; init; }
    public required String lastName { get; init; }
    public required String phoneNumber { get; init; }
    public required DateTime dob { get; init; }
    public required Gender gender { get; init; }
}