using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers;

public interface IParseBranchChainLink<TBuilder>
{
    void AddNext(IParseBranchChainLink<TBuilder> link);
    ParseResult Handle(Request request, TBuilder builder);
}