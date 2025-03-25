using Microsoft.EntityFrameworkCore;

namespace PatientlyService.Core.Data;

public class CorePatientlyServiceDBContext: DbContext
{
    public CorePatientlyServiceDBContext(DbContextOptions<CorePatientlyServiceDBContext> dbContextOptions): base(dbContextOptions)
    {
    }
}