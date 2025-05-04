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
    INTERNAL = 0,
    STAFF = 1,
    PATIENT = 2
}
public enum Gender {
    MALE = 0,
    FEMALE = 1,
    OTHER = 2
}
public enum Status {
    PENDING_REGISTRATION = 0,
    REGISTERED = 1,
    INACTIVE = 2
}

