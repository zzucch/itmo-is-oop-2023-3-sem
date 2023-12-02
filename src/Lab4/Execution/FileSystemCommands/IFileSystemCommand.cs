using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemProviders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;

public interface IFileSystemCommand
{
    void Execute(FileSystemProvider fileSystemProvider);
}