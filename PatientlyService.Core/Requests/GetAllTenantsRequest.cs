namespace PatientlyService.Core.Requests;

public class GetAllTenantsRequest
{
    public required string? SortBy { get; init; }
}