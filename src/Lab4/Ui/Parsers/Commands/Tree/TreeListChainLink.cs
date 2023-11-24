using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Tree;

public class TreeListChainLink : ParserChainLinkBase
{
    private const string CommandName = "list";

    public override ParseResult Handle(Request request)
    {
        if (string.Equals(request.Value.GetCurrent(), CommandName, StringComparison.Ordinal) is false)
        {
            return Next is null
                ? new ParseResult.Failure()
                : Next.Handle(request);
        }

        request.CommandContextBuilder.WithCommand(new TreeListCommand());

        if (BranchChainNext is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Success(request.CommandContextBuilder.Build());
        }

        return BranchChainNext.Handle(request);
    }
}