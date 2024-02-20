using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

public abstract record FileSystemSubtreeResult
{
    private FileSystemSubtreeResult()
    {
    }

    public sealed record Success(IEnumerable<TreeElement> TreeElements) : FileSystemSubtreeResult;

    public sealed record Failure(string Message) : FileSystemSubtreeResult;
}