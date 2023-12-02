using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.Parameters;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.File.Copies;

public class FileCopyChainLink : ParseChainLinkBase
{
    private const string CommandName = "copy";
    private readonly IParseBranchChainLink<FileCopyContext.Builder>? _branchChainLink;
    private readonly IDisplayDriver _displayDriver;

    public FileCopyChainLink(
        IParseBranchChainLink<FileCopyContext.Builder>? branchChainLink,
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

        var builder = new FileCopyContext.Builder();
        builder.WithDisplayDriver(_displayDriver);

        builder.WithSourcePath(new Path(request.Value.GetCurrent()));

        if (request.Value.TryMove() is false)
        {
            return new ParseResult.Failure();
        }

        builder.WithDestinationPath(new Path(request.Value.GetCurrent()));

        return _branchChainLink is null
            ? new ParseResult.Success(new FileCopyCommand(builder.Build()))
            : _branchChainLink.Handle(request, builder);
    }
}