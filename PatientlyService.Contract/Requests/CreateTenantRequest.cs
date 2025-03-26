namespace PatientlyService.Contract.Requests;

public class CreateTenantRequest
{
    public required string Name { get; init; }

    public required string StreetAddress { get; init; }
    
    public required string City { get; init; }
    
    public required string State { get; init; }
    
    public required string Country { get; init; }
    public required string ZipCode { get; init; }
    
    public required string PictureUrl { get; init; }

}