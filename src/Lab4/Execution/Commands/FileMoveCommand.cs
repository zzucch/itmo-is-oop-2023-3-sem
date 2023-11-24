using Itmo.ObjectOrientedProgramming.Lab4.Execution.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;

public class FileMoveCommand : ICommand
{
    public void Execute(CommandContext context)
    {
        if (context.FileSystemDriver == null)
        {
            context.DisplayDriver?.Write("File system not specified");
            return;
        }

        if (context.SourcePath == null)
        {
            context.DisplayDriver?.Write("Source path not specified");
            return;
        }

        if (context.DestinationPath == null)
        {
            context.DisplayDriver?.Write("Destination path not specified");
            return;
        }

        switch (context.FileSystemDriver.MoveFile(context.SourcePath, context.DestinationPath))
        {
            case FileSystemDriverResult.Success:
                break;
            case FileSystemDriverResult.Failure failure:
                context.DisplayDriver?.Write(failure.Message);
                break;
        }
    }
}