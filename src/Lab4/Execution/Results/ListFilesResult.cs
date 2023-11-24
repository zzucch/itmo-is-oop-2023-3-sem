namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

public abstract record ListFilesResult
{
    private ListFilesResult()
    {
    }

    public sealed record Success(string List) : ListFilesResult;

    public sealed record Failure(string Message) : ListFilesResult;
}