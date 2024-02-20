using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemProviders;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;

public class FileCopyCommand : IFileSystemCommand
{
    private readonly FileCopyContext _context;

    public FileCopyCommand(FileCopyContext context)
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

        switch (fileSystemProvider.CopyFile(_context.SourcePath, _context.DestinationPath))
        {
            case FileSystemDriverResult.Success:
                break;
            case FileSystemDriverResult.Failure failure:
                _context.DisplayDriver.Write(failure.Message);
                break;
        }
    }
}