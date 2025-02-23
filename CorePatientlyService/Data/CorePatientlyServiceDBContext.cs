using Microsoft.EntityFrameworkCore;

namespace CorePatientlyService.Data;

public class CorePatientlyServiceDBContext: DbContext
{
    public CorePatientlyServiceDBContext(DbContextOptions<CorePatientlyServiceDBContext> dbContextOptions): base(dbContextOptions)
    {
    }
}