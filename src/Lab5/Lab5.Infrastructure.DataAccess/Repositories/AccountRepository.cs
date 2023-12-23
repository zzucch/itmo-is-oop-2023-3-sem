using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Accounts;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Account? FindAccountById(long id)
    {
        const string sql =
            """
            select u.user_name, a.account_password
            from accounts a
            natural join public.users u
            where account_id = :id;
            """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new Account(
            Username: reader.GetString(0),
            Id: id,
            Password: reader.GetString(1));
    }

    public Account? AddAccount(string username, string password)
    {
        const string sql1 =
            """
            insert into accounts
            values (default, (select user_id
                              from users
                              where users.user_name = :username
                              limit 1), :balance, :password)
            """;

        NpgsqlConnection connection1 = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using (var command1 = new NpgsqlCommand(sql1, connection1))
        {
            command1.AddParameter("username", username);
            command1.AddParameter("balance", 0);
            command1.AddParameter("password", password);

            command1.ExecuteNonQuery();
        }

        const string sql2 =
            """
            select a.account_id
            from accounts a
            natural join public.users u
            where u.user_name = :username and a.account_password = :password
            limit 1
            """;

        NpgsqlConnection connection2 = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command2 = new NpgsqlCommand(sql2, connection2);

        command2.AddParameter("username", username);
        command2.AddParameter("password", password);

        NpgsqlDataReader reader = command2.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new Account(
            Username: username,
            Id: reader.GetInt64(0),
            Password: password);
    }

    public decimal GetBalance(long id)
    {
        const string sql =
            """
            select account_balance
            from accounts
            where account_id = :id;
            """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);

        using NpgsqlDataReader reader = command.ExecuteReader();

        return reader.Read() is false
            ? decimal.Zero
            : reader.GetDecimal(0);
    }

    public void WithdrawMoney(long id, decimal amount)
    {
        const string sql =
            """
            update accounts
            set account_balance = account_balance - :amount
            where account_id = :id;
            """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);
        command.AddParameter("amount", amount);

        command.ExecuteNonQuery();
    }

    public void ReplenishMoney(long id, decimal amount)
    {
        const string sql =
            """
            update accounts
            set account_balance = account_balance + :amount
            where account_id = :id;
            """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", id);
        command.AddParameter("amount", amount);

        command.ExecuteNonQuery();
    }
}