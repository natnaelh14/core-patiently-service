namespace PatientlyService.Core.Responses;

public class UserResponse
{
    private Guid id;

    private String email;

    private String pictureUrl;

    private Guid roleId;

    private UserType userType;

    private String firstName;

    private String lastName;

    private String phoneNumber;

    private String dob;

    private Gender gender;

    private Status status;

    private DateTime createdAt;

    private DateTime modifiedAt;
}
public enum UserType {
    INTERNAL,
    STAFF,
    PATIENT
}

public enum Gender {
    MALE,
    FEMALE,
    OTHER
}

public enum Status {
    PENDING_REGISTRATION,
    REGISTERED,
    INACTIVE
}