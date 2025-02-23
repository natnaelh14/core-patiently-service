using CorePatientlyService.Data;

namespace CorePatientlyService.Repositories;

public class SQLStaffUserRepository: IStaffUserRepository
{
    private readonly CorePatientlyServiceDBContext dbContext;

    public SQLStaffUserRepository(CorePatientlyServiceDBContext dbContext)
    {
        this.dbContext = dbContext;
    }
}