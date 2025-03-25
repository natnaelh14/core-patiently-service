using PatientlyService.Core.Data;

namespace PatientlyService.Core.Repositories;

public class SQLStaffUserRepository: IStaffUserRepository
{
    private readonly CorePatientlyServiceDBContext dbContext;

    public SQLStaffUserRepository(CorePatientlyServiceDBContext dbContext)
    {
        this.dbContext = dbContext;
    }
}