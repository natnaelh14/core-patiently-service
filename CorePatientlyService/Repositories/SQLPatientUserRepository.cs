using CorePatientlyService.Data;

namespace CorePatientlyService.Repositories;

public class SQLPatientUserRepository: IPatientUserRepository
{
    private readonly CorePatientlyServiceDBContext dbContext;

    public SQLPatientUserRepository(CorePatientlyServiceDBContext dbContext)
    {
        this.dbContext = dbContext;
    }
}