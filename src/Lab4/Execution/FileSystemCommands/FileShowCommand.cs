using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemProviders;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;

public class FileShowCommand : IFileSystemCommand
{
    private readonly FileShowContext _context;

    public FileShowCommand(FileShowContext context)
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

        switch (fileSystemProvider.ReadFileData(_context.Path))
        {
            case FileDataResult.Success success:
                _context.ShowDisplayDriver.Write(success.Data);
                break;
            case FileDataResult.Failure failure:
                _context.DisplayDriver.Write(failure.Message);
                break;
        }
    }
}