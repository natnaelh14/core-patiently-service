namespace PatientlyService.Contract.Requests;

public class GetAllTenantsRequest
{
    public required string? SortBy { get; init; }
}