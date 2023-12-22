using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Users;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public User? FindUserByName(string username)
    {
        const string sql =
            """
            select user_name, user_password, user_role
            from users
            where user_name = :username;
            """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", username);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new User(
            Name: reader.GetString(0),
            Password: reader.GetString(1),
            Role: reader.GetFieldValue<UserRole>(2));
    }

    public User? TryAdminLogin(string password)
    {
        const string sql =
            """
            select user_name, user_password, user_role
            from users
            where user_role = 'admin'
            limit 1;
            """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
        {
            var newAdmin = new User("admin", password, UserRole.Admin);
            reader.DisposeAsync().Preserve();
            AddUser(newAdmin);
            return newAdmin;
        }

        var admin = new User(
            Name: reader.GetString(0),
            Password: reader.GetString(1),
            Role: reader.GetFieldValue<UserRole>(2));

        return string.Equals(password, admin.Password, StringComparison.Ordinal)
            ? admin
            : null;
    }

    public void AddUser(User user)
    {
        const string sql =
            """
            insert into accounts
            values (default, (select user_id
                              from users
                              where users.user_name = :username), :balance, :password)
            """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("name", user.Name);
        command.AddParameter("password", user.Password);

        command.ExecuteNonQuery();
    }
}