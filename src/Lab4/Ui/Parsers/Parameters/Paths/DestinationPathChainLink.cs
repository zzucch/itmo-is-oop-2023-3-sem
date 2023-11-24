using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Parameters.Paths;

public class DestinationPathChainLink : ParserChainLinkBase
{
    public override ParseResult Handle(Request request)
    {
        request.CommandContextBuilder.WithDestinationPath(new Path(request.Value.GetCurrent()));

        if (BranchChainNext is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Success(request.CommandContextBuilder.Build());
        }

        return BranchChainNext.Handle(request);
    }
}