namespace Lab5.Application.Contracts.Accounts.Results;

public abstract record BalanceResult
{
    private BalanceResult()
    {
    }

    public sealed record Success(decimal Balance) : BalanceResult;

    public sealed record Failure : BalanceResult;
}