using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Tree;

public class TreeGotoChainLink : ParserChainLinkBase
{
    private const string CommandName = "goto";

    public override ParseResult Handle(Request request)
    {
        if (string.Equals(request.Value.GetCurrent(), CommandName, StringComparison.Ordinal) is false)
        {
            return Next is null
                ? new ParseResult.Failure()
                : Next.Handle(request);
        }

        request.CommandContextBuilder.WithPath(new Path(request.Value.GetCurrent()));

        if (BranchChainNext is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Failure();
        }

        request.CommandContextBuilder.WithCommand(new TreeGotoCommand());
        return BranchChainNext.Handle(request);
    }
}