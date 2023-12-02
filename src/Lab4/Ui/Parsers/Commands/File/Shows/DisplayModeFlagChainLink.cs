using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.File.Shows;

public class DisplayModeFlagChainLink : ParseBranchChainLinkBase<FileShowContext.Builder>
{
    private const string FlagName = "-m";

    public override ParseResult Handle(Request request, FileShowContext.Builder builder)
    {
        if (string.Equals(request.Value.GetCurrent(), FlagName, StringComparison.Ordinal) is false)
        {
            return Next is null
                ? new ParseResult.Failure()
                : Next.Handle(request, builder);
        }

        if (Next is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Failure();
        }

        return Next.Handle(request, builder);
    }
}