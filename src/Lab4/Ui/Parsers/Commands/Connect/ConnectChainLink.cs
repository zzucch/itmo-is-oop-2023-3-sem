using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Connect;

public class ConnectChainLink : ParserChainLinkBase
{
    private const string CommandName = "connect";

    public override ParseResult Handle(Request request)
    {
        if (string.Equals(request.Value.GetCurrent(), CommandName, StringComparison.Ordinal) is false)
        {
            return Next is null
                ? new ParseResult.Failure()
                : Next.Handle(request);
        }

        if (BranchChainNext is null || !request.Value.TryMove())
        {
            return new ParseResult.Failure();
        }

        request.CommandContextBuilder.WithCommand(new ConnectCommand());
        return BranchChainNext.Handle(request);
    }
}