namespace PatientlyService.Core.Models.User;

public class UserResponseDTO
{
    private Guid id;

    private String email;

    private String pictureUrl;

    private Guid roleId;

    private User.UserType userType;

    private String firstName;

    private String lastName;

    private String phoneNumber;

    private String dob;

    private User.Gender gender;

    private User.Status status;

    private DateTime createdAt;

    private DateTime modifiedAt;
}
