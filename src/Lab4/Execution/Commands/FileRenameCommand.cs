using Itmo.ObjectOrientedProgramming.Lab4.Execution.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;

public class FileRenameCommand : ICommand
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

        if (context.FileName == null)
        {
            context.DisplayDriver?.Write("Address not specified");
            return;
        }

        switch (context.FileSystemDriver.RenameFile(context.Path, context.FileName))
        {
            case FileSystemDriverResult.Success:
                break;
            case FileSystemDriverResult.Failure failure:
                context.DisplayDriver?.Write(failure.Message);
                break;
        }
    }
}