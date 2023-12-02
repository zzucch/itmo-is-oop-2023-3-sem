using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemProviders;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;

public class FileDeleteCommand : IFileSystemCommand
{
    private readonly FileDeleteContext _context;

    public FileDeleteCommand(FileDeleteContext context)
    {
        _context = context;
    }

    public void Execute(FileSystemProvider fileSystemProvider)
    {
        if (fileSystemProvider.FileExists(_context.Path) is false)
        {
            _context.DisplayDriver.Write("File does not exist");
            return;
        }

        switch (fileSystemProvider.DeleteFile(_context.Path))
        {
            case FileSystemDriverResult.Success:
                break;
            case FileSystemDriverResult.Failure failure:
                _context.DisplayDriver.Write(failure.Message);
                break;
        }
    }
}