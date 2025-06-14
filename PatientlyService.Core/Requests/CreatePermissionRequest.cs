using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Requests;

public class CreatePermissionRequest
{
    public required PermissionCode PermissionCode { get; init; }
    public required string Description { get; init; }
    public required Category Category { get; init; }
    public required bool IsEnabled { get; init; }
}