using Dapper;

namespace PatientlyService.Core.Database;

public class DbInitializer
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public DbInitializer(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        
        await connection.ExecuteAsync("""
                                          create table if not exists tenants (
                                          id UUID primary key,
                                          name TEXT not null, 
                                          streetaddress TEXT not null,
                                          city TEXT not null,
                                          state TEXT not null,
                                          country TEXT not null,
                                          zipcode TEXT not null,
                                          pictureurl TEXT not null
                                         );
                                      """);
    }
}