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
                                          CREATE TABLE IF NOT EXISTS tenants (
                                          id UUID primary key,
                                          name TEXT not null, 
                                          streetaddress TEXT not null,
                                          city TEXT not null,
                                          state TEXT not null,
                                          country TEXT not null,
                                          zipcode TEXT not null,
                                          pictureurl TEXT not null
                                          );
                                          CREATE TABLE IF NOT EXISTS users (
                                          id UUID primary key,
                                          email TEXT not null, 
                                          password TEXT not null,
                                          pictureurl TEXT not null,
                                          roleid UUID not null,
                                          status TEXT not null,
                                          usertype INT not null,
                                          firstname TEXT not null,
                                          middlename TEXT not null,
                                          lastname TEXT not null,
                                          phonenumber TEXT not null,
                                          dob TEXT not null,
                                          gender INT not null
                                          );
                                          CREATE TABLE IF NOT EXISTS sessions (
                                          id UUID PRIMARY KEY,
                                          tenantid UUID NOT NULL,
                                          roleid UUID NOT NULL,
                                          usertype INT NOT NULL,
                                          prefix TEXT NOT NULL,
                                          firstname TEXT NOT NULL,
                                          email TEXT NOT NULL,
                                          FOREIGN KEY (tenantid) REFERENCES tenants (id) ON DELETE CASCADE
                                          );
                                      """);
    }
}