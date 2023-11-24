using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Parameters;

public class FileNameChainLink : ParserChainLinkBase
{
    public override ParseResult Handle(Request request)
    {
        request.CommandContextBuilder.WithFileName(request.Value.GetCurrent());

        if (BranchChainNext is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Success(request.CommandContextBuilder.Build());
        }

        return BranchChainNext.Handle(request);
    }
}