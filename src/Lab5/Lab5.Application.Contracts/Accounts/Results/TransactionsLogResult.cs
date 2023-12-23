using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Contracts.Accounts.Results;

public abstract record TransactionsLogResult
{
    private TransactionsLogResult()
    {
    }

    public sealed record Success(IEnumerable<Transaction> Transactions)
        : TransactionsLogResult;

    public sealed record Failure : TransactionsLogResult;
}