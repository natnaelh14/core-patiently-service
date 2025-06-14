using System.ComponentModel;

namespace PatientlyService.Core.Models.User;

public class Permission
{
    public Guid Id;
    public PermissionCode PermissionCode;
    public String Description;
    public Category Category;
    public Boolean IsEnabled;
}

public enum PermissionCode
{
    [Description("View Patient Demographics")]
    PATIENT_DEMOGRAPHICS_VIEW,

    [Description("Edit Patient Demographics")]
    PATIENT_DEMOGRAPHICS_EDIT,

    [Description("Add New Patient Demographics")]
    PATIENT_DEMOGRAPHICS_ADD,

    [Description("View Clinical Notes")]
    CLINICAL_NOTES_VIEW,

    [Description("Add Clinical Notes")]
    CLINICAL_NOTES_ADD,

    [Description("Create Lab Order")]
    LAB_ORDER_CREATE
}

public enum Category
{
    PATIENT,
    CLINICAL,
    ORDER,
    LAB
}