using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Tree.Lists;

public class TreeListChainLink : ParseChainLinkBase
{
    private const string CommandName = "list";
    private const int DefaultDepth = 1;
    private readonly IParseBranchChainLink<TreeListContext.Builder>? _branchChainLink;
    private readonly IDisplayDriver _displayDriver;
    private readonly IVisitor _visitor;

    public TreeListChainLink(
        IParseBranchChainLink<TreeListContext.Builder>? branchChainLink,
        IDisplayDriver displayDriver,
        IVisitor visitor)
    {
        _branchChainLink = branchChainLink;
        _displayDriver = displayDriver;
        _visitor = visitor;
    }

    public override ParseResult Handle(Request request)
    {
        if (string.Equals(request.Value.GetCurrent(), CommandName, StringComparison.Ordinal) is false)
        {
            return Next is null
                ? new ParseResult.Failure()
                : Next.Handle(request);
        }

        var builder = new TreeListContext.Builder();

        builder.WithDisplayDriver(_displayDriver);
        builder.WithDepth(DefaultDepth);

        if (_branchChainLink is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Success(new TreeListCommand(builder.Build(), _visitor));
        }

        return _branchChainLink.Handle(request, builder);
    }
}