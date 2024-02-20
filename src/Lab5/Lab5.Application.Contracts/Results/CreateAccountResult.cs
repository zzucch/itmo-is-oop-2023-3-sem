namespace Lab5.Application.Contracts.Results;

public abstract record CreateAccountResult
{
    private CreateAccountResult()
    {
    }

    public sealed record Success(long Id) : CreateAccountResult;

    public sealed record Failure : CreateAccountResult;
}