using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.FileSystemDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.Parameters;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Connect;

public class ConnectChainLink : ParseChainLinkBase
{
    private const string CommandName = "connect";
    private const string FlagName = "-m";
    private const string LocalConnectionModeName = "local";
    private readonly IParseBranchChainLink<ConnectContext.Builder>? _branchChainLink;
    private readonly IDisplayDriver _displayDriver;

    public ConnectChainLink(IParseBranchChainLink<ConnectContext.Builder>? branchChainLink, IDisplayDriver displayDriver)
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

        var builder = new ConnectContext.Builder();
        builder.WithDisplayDriver(_displayDriver);

        if (request.Value.TryMove() is false)
        {
            return new ParseResult.Failure();
        }

        builder.WithPath(new Path(request.Value.GetCurrent()));

        if (request.Value.TryMove() is false)
        {
            return new ParseResult.Failure();
        }

        if (string.Equals(request.Value.GetCurrent(), FlagName, StringComparison.Ordinal) is false)
        {
            return new ParseResult.Failure();
        }

        if (request.Value.TryMove() is false)
        {
            return new ParseResult.Failure();
        }

        if (string.Equals(request.Value.GetCurrent(), LocalConnectionModeName, StringComparison.Ordinal) is false)
        {
            return new ParseResult.Failure();
        }

        builder.WithFileSystemDriver(new LocalFileSystemDriver());

        return _branchChainLink is null
            ? new ParseResult.Success(new ConnectCommand(builder.Build()))
            : _branchChainLink.Handle(request, builder);
    }
}