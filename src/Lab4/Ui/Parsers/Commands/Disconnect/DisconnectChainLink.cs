using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Disconnect;

public class DisconnectChainLink : ParserChainLinkBase
{
    private const string CommandName = "disconnect";

    public override ParseResult Handle(Request request)
    {
        if (string.Equals(request.Value.GetCurrent(), CommandName, StringComparison.Ordinal) is false)
        {
            return Next is null
                ? new ParseResult.Failure()
                : Next.Handle(request);
        }

        if (BranchChainNext is not null && request.Value.TryMove())
        {
            return BranchChainNext.Handle(request);
        }

        request.CommandContextBuilder.WithCommand(new DisconnectCommand());
        return new ParseResult.Success(request.CommandContextBuilder.Build());
    }
}