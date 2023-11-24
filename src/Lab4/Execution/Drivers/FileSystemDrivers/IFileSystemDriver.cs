using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.FileSystemDrivers;

public interface IFileSystemDriver
{
    FileSystemDriverResult Connect(Path address);
    FileSystemDriverResult Disconnect();
    FileSystemDriverResult ChangeDirectory(Path path);
    FileDataResult ReadFileData(Path path);
    FileSystemDriverResult MoveFile(Path source, Path destination);
    FileSystemDriverResult CopyFile(Path source, Path destination);
    FileSystemDriverResult DeleteFile(Path path);
    FileSystemDriverResult RenameFile(Path path, string name);
    FileSystemDriverResult CreateFile(Path path, string data);
    ListFilesResult TreeList(int depth, TreeListParameters parameters);
}