using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Disconnect;

public class DisconnectChainLink : ParseChainLinkBase
{
    private const string CommandName = "disconnect";
    private readonly IParseBranchChainLink<DisconnectContext.Builder>? _branchChainLink;
    private readonly IDisplayDriver _displayDriver;

    public DisconnectChainLink(
        IParseBranchChainLink<DisconnectContext.Builder>? branchChainLink,
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

        var builder = new DisconnectContext.Builder();
        builder.WithDisplayDriver(_displayDriver);

        if (_branchChainLink is not null && request.Value.TryMove())
        {
            return _branchChainLink.Handle(request, builder);
        }

        return new ParseResult.Success(new DisconnectCommand(builder.Build()));
    }
}