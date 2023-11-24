using Itmo.ObjectOrientedProgramming.Lab4.Execution.CommandContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers;

public abstract record ParseResult
{
    private ParseResult()
    {
    }

    public sealed record Success(CommandContext CommandContext) : ParseResult;

    public sealed record Failure : ParseResult;
}