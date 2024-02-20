using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.Parameters;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Tree.Gotos;

public class TreeGotoChainLink : ParseChainLinkBase
{
    private const string CommandName = "goto";
    private readonly IParseBranchChainLink<TreeGotoContext.Builder>? _branchChainLink;
    private readonly IDisplayDriver _displayDriver;

    public TreeGotoChainLink(
        IParseBranchChainLink<TreeGotoContext.Builder>? branchChainLink,
        IDisplayDriver displayDriver)
    {
        _branchChainLink = branchChainLink;
        _displayDriver = displayDriver;
    }

    public override ParseResult Handle(Request request)
    {
        if (string.Equals(request.Value.GetCurrent(), CommandName, StringComparison.Ordinal) is false)
        {
            return Next is null
                ? new ParseResult.Failure()
                : Next.Handle(request);
        }

        var builder = new TreeGotoContext.Builder();

        builder.WithDisplayDriver(_displayDriver);
        builder.WithPath(new Path(request.Value.GetCurrent()));

        if (_branchChainLink is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Success(new TreeGotoCommand(builder.Build()));
        }

        return _branchChainLink.Handle(request, builder);
    }
}