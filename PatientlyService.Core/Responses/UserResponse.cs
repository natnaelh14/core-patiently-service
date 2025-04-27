using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Responses;

public class UserResponse
{
    public Guid Id { get; init; }
    public String Email { get; init; }
    public String PictureUrl { get; init; }
    public Guid RoleId { get; init; }
    public UserType UserType { get; init; }
    public Status Status { get; init; }
    public String FirstName { get; init; }
    public String MiddleName { get; init; }
    public String LastName { get; init; }
    public String PhoneNumber { get; init; }
    public DateTime DOB { get; init; } 
    public Gender Gender { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime ModifiedAt { get; init; }
}
