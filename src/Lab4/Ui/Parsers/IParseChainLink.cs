using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers;

public interface IParseChainLink
{
    void AddNext(IParseChainLink link);
    ParseResult Handle(Request request);
}