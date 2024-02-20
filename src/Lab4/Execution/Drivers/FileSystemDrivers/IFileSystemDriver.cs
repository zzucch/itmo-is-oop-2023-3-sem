using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.Parameters;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.FileSystemDrivers;

public interface IFileSystemDriver
{
    bool FileExists(Path path);
    bool DirectoryExists(Path path);
    bool IsAbsolutePath(Path path);
    Path? FindAbsolutePath(Path root, Path path);
    FileDataResult ReadFileData(Path path);
    FileSystemDriverResult MoveFile(Path source, Path destination);
    FileSystemDriverResult RenameFile(Path source, string fileName);
    FileSystemDriverResult CopyFile(Path source, Path destination);
    FileSystemDriverResult DeleteFile(Path path);
    FileSystemSubtreeResult GetSubtree(Path path, int depth);
}