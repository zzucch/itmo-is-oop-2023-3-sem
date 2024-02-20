namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

public abstract record FileSystemDriverResult
{
    private FileSystemDriverResult()
    {
    }

    public sealed record Success : FileSystemDriverResult;

    public sealed record Failure(string Message) : FileSystemDriverResult;
}