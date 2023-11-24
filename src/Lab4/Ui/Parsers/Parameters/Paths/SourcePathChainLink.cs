using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Parameters.Paths;

public class SourcePathChainLink : ParserChainLinkBase
{
    public override ParseResult Handle(Request request)
    {
        request.CommandContextBuilder.WithSourcePath(new Path(request.Value.GetCurrent()));

        if (BranchChainNext is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Failure();
        }

        return BranchChainNext.Handle(request);
    }
}