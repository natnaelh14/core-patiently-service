namespace CorePatientlyService.Models.User;

public class PatientUser
{
    private Guid id;

    private Guid userId;

    private String ssn;

    private IdentificationType identificationType;

    private String identificationUrl;

    private Boolean treatmentConsentChecked;

    private Boolean privacyConsentChecked;

    private Boolean disclosureConsent;
    private enum IdentificationType {
        DRIVERS_LICENSE,
        PASSPORT,
        STATE_ID,
        MILITARY_ID,
        OTHER
    }
}