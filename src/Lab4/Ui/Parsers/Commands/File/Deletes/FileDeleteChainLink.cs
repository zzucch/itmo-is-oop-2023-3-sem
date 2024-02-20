using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.Parameters;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.File.Deletes;

public class FileDeleteChainLink : ParseChainLinkBase
{
    private const string CommandName = "delete";
    private readonly IParseBranchChainLink<FileDeleteContext.Builder>? _branchChainLink;
    private readonly IDisplayDriver _displayDriver;

    public FileDeleteChainLink(
        IParseBranchChainLink<FileDeleteContext.Builder>? branchChainLink,
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

        if (request.Value.TryMove() is false)
        {
            return new ParseResult.Failure();
        }

        var builder = new FileDeleteContext.Builder();
        builder.WithDisplayDriver(_displayDriver);

        builder.WithPath(new Path(request.Value.GetCurrent()));

        return _branchChainLink is null
            ? new ParseResult.Success(new FileDeleteCommand(builder.Build()))
            : _branchChainLink.Handle(request, builder);
    }
}