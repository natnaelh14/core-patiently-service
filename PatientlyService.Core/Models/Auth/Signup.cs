using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Models.Auth;

public class Signup
{
    private String Email;

    private String Password;

    private Guid RoleID;

    private UserType UserType;

    private String FirstName;

    private String LastName;

    private String MiddleName;

    private String PhoneNumber;

    private String DOB;

    private Gender Gender;

    private String PictureUrl;

    //PATIENT USER fields

    private String JobTitle;

    //STAFF USER fields

    private Boolean TreatmentConsentChecked;

    private Boolean PrivacyConsentChecked;

    private Boolean DisclosureConsent;

    // Common field for PATIENT and STAFF user
    private Guid TenantId;
}