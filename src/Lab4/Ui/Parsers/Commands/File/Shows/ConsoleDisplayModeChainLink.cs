using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.File.Shows;

public class ConsoleDisplayModeChainLink : ParseBranchChainLinkBase<FileShowContext.Builder>
{
    private const string ModeName = "console";

    public override ParseResult Handle(Request request, FileShowContext.Builder builder)
    {
        if (string.Equals(ModeName, request.Value.GetCurrent(), StringComparison.Ordinal) is false)
        {
            return Next is null
                ? new ParseResult.Failure()
                : Next.Handle(request, builder);
        }

        builder.WithShowDisplayDriver(new ConsoleDisplayDriver());

        if (Next is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Success(new FileShowCommand(builder.Build()));
        }

        return Next.Handle(request, builder);
    }
}