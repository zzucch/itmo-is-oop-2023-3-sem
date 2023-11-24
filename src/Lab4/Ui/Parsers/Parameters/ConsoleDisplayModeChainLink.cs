using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Parameters;

public class ConsoleDisplayModeChainLink : ParserChainLinkBase
{
    private const string ModeName = "console";

    public override ParseResult Handle(Request request)
    {
        if (string.Equals(ModeName, request.Value.GetCurrent(), StringComparison.Ordinal) is false)
        {
            return Next is null
                ? new ParseResult.Failure()
                : Next.Handle(request);
        }

        request.CommandContextBuilder.WithDisplayDriver(new ConsoleDisplayDriver());

        if (BranchChainNext is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Success(request.CommandContextBuilder.Build());
        }

        return BranchChainNext.Handle(request);
    }
}