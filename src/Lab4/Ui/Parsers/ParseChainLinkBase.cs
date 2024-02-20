using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers;

public abstract class ParseChainLinkBase : IParseChainLink
{
    protected IParseChainLink? Next { get; private set; }

    public void AddNext(IParseChainLink link)
    {
        if (Next is null)
        {
            Next = link;
        }
        else
        {
            Next.AddNext(link);
        }
    }

    public abstract ParseResult Handle(Request request);
}