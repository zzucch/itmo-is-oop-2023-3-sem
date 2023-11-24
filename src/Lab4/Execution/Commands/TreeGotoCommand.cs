using Itmo.ObjectOrientedProgramming.Lab4.Execution.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;

public class TreeGotoCommand : ICommand
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

        switch (context.FileSystemDriver.ChangeDirectory(context.Path))
        {
            case FileSystemDriverResult.Success:
                break;
            case FileSystemDriverResult.Failure failure:
                context.DisplayDriver?.Write(failure.Message);
                break;
        }
    }
}