using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.FileSystemDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Parameters;

public class LocalFileSystemModeChainLink : ParserChainLinkBase
{
    private const string ModeName = "local";

    public override ParseResult Handle(Request request)
    {
        if (string.Equals(ModeName, request.Value.GetCurrent(), StringComparison.Ordinal) is false)
        {
            return Next is null
                ? new ParseResult.Failure()
                : Next.Handle(request);
        }

        request.CommandContextBuilder.WithFileSystemDriver(new LocalFileSystemDriver());

        if (BranchChainNext is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Success(request.CommandContextBuilder.Build());
        }

        return BranchChainNext.Handle(request);
    }
}