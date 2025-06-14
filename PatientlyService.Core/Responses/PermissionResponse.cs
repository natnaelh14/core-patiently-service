using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Responses;

public class PermissionResponse
{
    public Guid Id { get; init; }
    public PermissionCode PermissionCode { get; init; }
    public string Description { get; init; }
    public Category Category { get; init; }
    public bool IsEnabled { get; init; }
}