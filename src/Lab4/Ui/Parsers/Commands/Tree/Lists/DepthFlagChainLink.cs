using System;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Tree.Lists;

public class DepthFlagChainLink : ParseBranchChainLinkBase<TreeListContext.Builder>
{
    private const string FlagName = "-d";
    private readonly IVisitor _visitor;

    public DepthFlagChainLink(IVisitor visitor)
    {
        _visitor = visitor;
    }

    public override ParseResult Handle(Request request, TreeListContext.Builder builder)
    {
        if (string.Equals(request.Value.GetCurrent(), FlagName, StringComparison.Ordinal) is false)
        {
            return new ParseResult.Failure();
        }

        if (Next is null || request.Value.TryMove() is false)
        {
            return new ParseResult.Success(new TreeListCommand(builder.Build(), _visitor));
        }

        return Next.Handle(request, builder);
    }
}