using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Parameters;

public class TreeListParametersChainLink : ParserChainLinkBase
{
    public override ParseResult Handle(Request request)
    {
        string current = request.Value.GetCurrent();

        request.CommandContextBuilder.WithTreeListParameters(
            new TreeListParameters(
                FileIcon: current.ElementAt(0),
                DirectoryIcon: current.ElementAt(1),
                Indentation: current.ElementAt(2)));

        if (BranchChainNext is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Success(request.CommandContextBuilder.Build());
        }

        return BranchChainNext.Handle(request);
    }
}