using CorePatientlyService.Models.Domain;

namespace CorePatientlyService.Models.DTO;

public class SignupDTO
{
    private String email;

    private String password;

    private Guid roleID;

    private User.UserType userType;

    private String firstName;

    private String lastName;

    private String middleName;

    private String phoneNumber;

    private String dob;

    private User.Gender gender;

    private String pictureUrl;

    //PATIENT USER fields

    private String jobTitle;

    //STAFF USER fields

    private Boolean treatmentConsentChecked;

    private Boolean privacyConsentChecked;

    private Boolean disclosureConsent;

    // Common field for PATIENT and STAFF user
    private Guid tenantId;
}