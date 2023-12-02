using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers;

public abstract record ParseResult
{
    private ParseResult()
    {
    }

    public sealed record Success(IFileSystemCommand Command) : ParseResult;

    public sealed record Failure : ParseResult;
}