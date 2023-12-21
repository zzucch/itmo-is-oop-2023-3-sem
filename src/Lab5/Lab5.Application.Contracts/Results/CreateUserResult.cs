namespace Lab5.Application.Contracts.Results;

public abstract record CreateUserResult
{
    private CreateUserResult()
    {
    }

    public sealed record Success : CreateUserResult;

    public sealed record Failure : CreateUserResult;
}