namespace PatientlyService.Core.Services;

public interface IAuthService
{
    Task<bool> StartRegistrationAsync(Guid id, CancellationToken token = default);
}
