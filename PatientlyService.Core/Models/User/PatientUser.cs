namespace PatientlyService.Core.Models.User;

public class PatientUser
{
    public Guid UserId;

    public String SSN;

    public IdentificationType IdentificationType;

    public String IdentificationUrl;

    public Boolean TreatmentConsentChecked;

    public Boolean PrivacyConsentChecked;

    public Boolean DisclosureConsent;
}
    public enum IdentificationType {
        DRIVERS_LICENSE,
        PASSPORT,
        STATE_ID,
        MILITARY_ID,
        OTHER
    }
