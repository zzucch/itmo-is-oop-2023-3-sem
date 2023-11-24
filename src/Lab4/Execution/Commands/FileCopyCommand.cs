using Itmo.ObjectOrientedProgramming.Lab4.Execution.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;

public class FileCopyCommand : ICommand
{
    public void Execute(CommandContext context)
    {
        if (context.FileSystemDriver == null)
        {
            context.DisplayDriver?.Write("File system not specified");
            return;
        }

        if (context.SourcePath is null)
        {
            context.DisplayDriver?.Write("Source file not specified");
            return;
        }

        if (context.DestinationPath is null)
        {
            context.DisplayDriver?.Write("Destination file not specified");
            return;
        }

        switch (context.FileSystemDriver.CopyFile(context.SourcePath, context.DestinationPath))
        {
            case FileSystemDriverResult.Success:
                break;
            case FileSystemDriverResult.Failure failure:
                context.DisplayDriver?.Write(failure.Message);
                break;
        }
    }
}