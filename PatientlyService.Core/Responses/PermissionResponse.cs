using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Responses;

public class PermissionResponse
{
    public Guid Id { get; init; }
    public string PermissionCode { get; init; }
    public string DisplayName { get; init; }
    public string Description { get; init; }
    public string Category { get; init; }
    public bool IsEnabled { get; init; }
}