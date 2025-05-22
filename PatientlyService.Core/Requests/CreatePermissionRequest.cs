namespace PatientlyService.Core.Requests;

public class CreatePermissionRequest
{
    public required string PermissionCode { get; init; }
    public required string DisplayName { get; init; }
    public required string Description { get; init; }
    public required string Category { get; init; }
    public required bool IsEnabled { get; init; }
}