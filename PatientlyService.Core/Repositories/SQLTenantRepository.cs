using PatientlyService.Core.Data;

namespace PatientlyService.Core.Repositories;

public class SQLTenantRepository: ITenantRepository
{
    private readonly CorePatientlyServiceDBContext dbContext;

    public SQLTenantRepository(CorePatientlyServiceDBContext dbContext)
    {
        this.dbContext = dbContext;
    }
}