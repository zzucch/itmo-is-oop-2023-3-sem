using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers;

public abstract class ParseBranchChainLinkBase<TBuilder> : IParseBranchChainLink<TBuilder>
{
    protected IParseBranchChainLink<TBuilder>? Next { get; private set; }

    public void AddNext(IParseBranchChainLink<TBuilder> link)
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

    public abstract ParseResult Handle(Request request, TBuilder builder);
}