using System;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Parameters.Flags;

public class DFlagChainLink : ParserChainLinkBase
{
    private const string FlagName = "-d";

    public override ParseResult Handle(Request request)
    {
        if (string.Equals(request.Value.GetCurrent(), FlagName, StringComparison.Ordinal) is false)
        {
            return Next is null
                ? new ParseResult.Failure()
                : Next.Handle(request);
        }

        if (BranchChainNext is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Failure();
        }

        return BranchChainNext.Handle(request);
    }
}