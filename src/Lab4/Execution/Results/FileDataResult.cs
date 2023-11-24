namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

public abstract record FileDataResult
{
    private FileDataResult()
    {
    }

    public sealed record Success(string Data) : FileDataResult;

    public sealed record Failure(string Message) : FileDataResult;
}