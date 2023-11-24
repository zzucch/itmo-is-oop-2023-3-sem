using Itmo.ObjectOrientedProgramming.Lab4.Execution.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;

public class FileShowCommand : ICommand
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

        switch (context.FileSystemDriver.ReadFileData(context.Path))
        {
            case FileDataResult.Success success:
                context.DisplayDriver?.Write(success.Data);
                break;
            case FileDataResult.Failure failure:
                context.DisplayDriver?.Write(failure.Message);
                break;
        }
    }
}