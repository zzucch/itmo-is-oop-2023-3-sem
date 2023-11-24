using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Parameters;

public class DepthChainLink : ParserChainLinkBase
{
    public override ParseResult Handle(Request request)
    {
        if (int.TryParse(request.Value.GetCurrent(), CultureInfo.InvariantCulture, out int depth))
        {
            request.CommandContextBuilder.WithDepth(depth);
        }

        if (BranchChainNext is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Success(request.CommandContextBuilder.Build());
        }

        return BranchChainNext.Handle(request);
    }
}