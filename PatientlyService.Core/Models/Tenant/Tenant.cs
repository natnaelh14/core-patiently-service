namespace PatientlyService.Core.Models.Tenant;

public partial class Tenant
{
    public Guid Id;

    public String Name;

    public String StreetAddress;

    public String City;
    
    public String State;

    public String Country;

    public String ZipCode;

    public String PictureUrl;
}

public class GetAllTenantsOptions
{
    public string? SortField { get; set; }

    public SortOrder? SortOrder { get; set; }
    
}

public enum SortOrder
{
    Unsorted,
    Ascending,
    Descending
}