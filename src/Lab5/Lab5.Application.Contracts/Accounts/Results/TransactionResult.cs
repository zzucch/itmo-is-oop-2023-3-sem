namespace Lab5.Application.Contracts.Accounts.Results;

public abstract record TransactionResult
{
    private TransactionResult()
    {
    }

    public sealed record Success : TransactionResult;

    public sealed record Failure : TransactionResult;
}