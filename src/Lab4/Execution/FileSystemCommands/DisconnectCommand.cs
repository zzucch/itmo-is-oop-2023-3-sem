using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemProviders;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;

public class DisconnectCommand : IFileSystemCommand
{
    private readonly DisconnectContext _context;

    public DisconnectCommand(DisconnectContext context)
    {
        _context = context;
    }

    public void Execute(FileSystemProvider fileSystemProvider)
    {
        switch (fileSystemProvider.Disconnect())
        {
            case FileSystemDriverResult.Success:
                break;
            case FileSystemDriverResult.Failure failure:
                _context.DisplayDriver.Write(failure.Message);
                break;
        }
    }
}