namespace PatientlyService.Core.Models.User;

public class User
{
    private Guid Id;
    private String Email;
    private String Password; 
    private String PictureUrl;
    private Guid RoleId;
    private Status Status;
    private UserType UserType;
    private String FirstName;
    private String MiddleName;
    private String LastName;
    private String PhoneNumber;
    private String DOB;
    private Gender Gender;
    private DateTime CreatedAt;
    private DateTime ModifiedAt;
}

    // Enum declarations
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

