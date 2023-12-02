using System;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Tree;

public class TreeChainLink : ParseChainLinkBase
{
    private const string CommandName = "tree";
    private readonly IParseChainLink _innerChainLink;

    public TreeChainLink(IParseChainLink innerChainLink)
    {
        _innerChainLink = innerChainLink;
    }

    public override ParseResult Handle(Request request)
    {
        if (string.Equals(request.Value.GetCurrent(), CommandName, StringComparison.Ordinal) is false)
        {
            return Next is null
                ? new ParseResult.Failure()
                : Next.Handle(request);
        }

        return request.Value.TryMove() is false
            ? new ParseResult.Failure()
            : _innerChainLink.Handle(request);
    }
}