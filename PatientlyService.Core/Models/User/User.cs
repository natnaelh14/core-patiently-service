namespace PatientlyService.Core.Models.User;

public class User
{
    private Guid id;
    
    private String email;

    private String password; 

    private String pictureUrl;

    private Guid roleId;

    private Status status;

    private UserType userType;

    private String firstName;
    
    private String middleName;
    
    private String lastName;

    private String phoneNumber;
    
    private String dob;

    private String encryptedGender;
    
    private DateTime createdAt;
    
    private DateTime modifiedAt;
 
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
}