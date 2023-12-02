using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemProviders;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;

public class FileRenameCommand : IFileSystemCommand
{
    private readonly FileRenameContext _context;

    public FileRenameCommand(FileRenameContext context)
    {
        _context = context;
    }

    public void Execute(FileSystemProvider fileSystemProvider)
    {
        if (fileSystemProvider.FileExists(_context.Path) is false)
        {
            _context.DisplayDriver.Write("Source file does not exist");
            return;
        }

        switch (fileSystemProvider.RenameFile(_context.Path, _context.FileName))
        {
            case FileSystemDriverResult.Success:
                break;
            case FileSystemDriverResult.Failure failure:
                _context.DisplayDriver.Write(failure.Message);
                break;
        }
    }
}