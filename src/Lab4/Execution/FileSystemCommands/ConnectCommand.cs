using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemProviders;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;

public class ConnectCommand : IFileSystemCommand
{
    private readonly ConnectContext _context;

    public ConnectCommand(ConnectContext context)
    {
        _context = context;
    }

    public void Execute(FileSystemProvider fileSystemProvider)
    {
        switch (fileSystemProvider.Connect(_context.FileSystemDriver, _context.Path))
        {
            case FileSystemDriverResult.Success:
                break;
            case FileSystemDriverResult.Failure failure:
                _context.DisplayDriver.Write(failure.Message);
                break;
        }
    }
}