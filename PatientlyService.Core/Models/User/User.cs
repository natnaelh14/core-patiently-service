namespace PatientlyService.Core.Models.User;

public class User
{
    public Guid Id;
    public String Email;
    public String Password; 
    public String PictureUrl;
    public Guid RoleId;
    public Status Status;
    public UserType UserType;
    public String FirstName;
    public String MiddleName;
    public String LastName;
    public String PhoneNumber;
    public DateTime DOB;
    public Gender Gender;
    public DateTime CreatedAt;
    public DateTime ModifiedAt;
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

