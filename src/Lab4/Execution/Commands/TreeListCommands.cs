using Itmo.ObjectOrientedProgramming.Lab4.Execution.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;

public class TreeListCommands : ICommand
{
    public void Execute(CommandContext context)
    {
        if (context.FileSystemDriver == null)
        {
            context.DisplayDriver?.Write("File system not specified");
            return;
        }

        if (context.Path == null)
        {
            context.DisplayDriver?.Write("Address not specified");
            return;
        }

        switch (context.FileSystemDriver.TreeList(
                    context.Depth,
                    context.TreeListParameters))
        {
            case ListFilesResult.Success success:
                context.DisplayDriver?.Write(success.List);
                break;
            case ListFilesResult.Failure failure:
                context.DisplayDriver?.Write(failure.Message);
                break;
        }
    }
}