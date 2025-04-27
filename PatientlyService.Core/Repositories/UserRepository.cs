using Dapper;
using PatientlyService.Core.Database;
using PatientlyService.Core.Models.User;

namespace PatientlyService.Core.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public UserRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<bool> CreateAsync(User user, Guid sessionId, CancellationToken token = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(token);
        var sql = @"
        INSERT INTO users (
            id, email, password, pictureurl, roleid, status, usertype, firstname, middlename, lastname, phonenumber, dob, gender
        ) VALUES (
            @Id, @Email, @Password, @PictureUrl, @RoleId, @Status, @UserType, @FirstName, @MiddleName, @LastName, @PhoneNumber, @DOB, @Gender
        )";

        var result = await connection.ExecuteAsync(
            new CommandDefinition(
                sql,
                new
                {
                    user.Id,
                    user.Email,
                    user.Password,
                    user.PictureUrl,
                    user.RoleId,
                    user.Status,
                    user.UserType,
                    user.FirstName,
                    user.MiddleName,
                    user.LastName,
                    user.PhoneNumber,
                    user.DOB,
                    user.Gender,
                    user.CreatedAt,
                    user.ModifiedAt
                },
                cancellationToken: token)
        );
        return result > 0;
    }
}