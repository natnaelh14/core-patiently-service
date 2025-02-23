using CorePatientlyService.Data;

namespace CorePatientlyService.Repositories;

public class SQLTenantRepository: ITenantRepository
{
    private readonly CorePatientlyServiceDBContext dbContext;

    public SQLTenantRepository(CorePatientlyServiceDBContext dbContext)
    {
        this.dbContext = dbContext;
    }
}