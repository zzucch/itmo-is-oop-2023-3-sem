using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemProviders;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;

public class TreeGotoCommand : IFileSystemCommand
{
    private readonly TreeGotoContext _context;

    public TreeGotoCommand(TreeGotoContext context)
    {
        _context = context;
    }

    public void Execute(FileSystemProvider fileSystemProvider)
    {
        if (fileSystemProvider.DirectoryExists(_context.Path) is false)
        {
            _context.DisplayDriver.Write("Source file does not exist");
            return;
        }

        switch (fileSystemProvider.ChangeDirectory(_context.Path))
        {
            case FileSystemDriverResult.Success:
                break;
            case FileSystemDriverResult.Failure failure:
                _context.DisplayDriver.Write(failure.Message);
                break;
        }
    }
}