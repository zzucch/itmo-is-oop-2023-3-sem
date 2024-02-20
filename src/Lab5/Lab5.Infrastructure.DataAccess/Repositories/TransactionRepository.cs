using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Transactions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<Transaction> GetAllAccountTransactions(long accountId)
    {
        const string sql =
            """
            select *
            from transactions
            where account_id = :id;
            """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", accountId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read() is not false)
        {
            yield return new Transaction(
                reader.GetDecimal(2),
                reader.GetFieldValue<TransactionType>(3));
        }
    }

    public void AddTransaction(long accountId, Transaction transaction)
    {
        const string sql =
            """
            insert into transactions values (default, :id, :amount, CAST(:type as transaction_type))
            """;

        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .Preserve()
            .GetAwaiter()
            .GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", accountId);
        command.AddParameter("amount", transaction.Amount);
        command.AddParameter("type", transaction.Type);

        command.ExecuteNonQuery();
    }
}