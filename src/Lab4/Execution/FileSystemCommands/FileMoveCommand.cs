using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemProviders;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;

public class FileMoveCommand : IFileSystemCommand
{
    private readonly FileMoveContext _context;

    public FileMoveCommand(FileMoveContext context)
    {
        _context = context;
    }

    public void Execute(FileSystemProvider fileSystemProvider)
    {
        if (fileSystemProvider.FileExists(_context.SourcePath) is false)
        {
            _context.DisplayDriver.Write("Source file does not exist");
            return;
        }

        switch (fileSystemProvider.MoveFile(_context.SourcePath, _context.DestinationPath))
        {
            case FileSystemDriverResult.Success:
                break;
            case FileSystemDriverResult.Failure failure:
                _context.DisplayDriver.Write(failure.Message);
                break;
        }
    }
}