using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.FileSystemDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.Parameters;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemProviders;

public class FileSystemProvider
{
    private const string NotConnectedMessage = "not connected to any file system";
    private const string InvalidPathMessage = "provided path is invalid";
    private IFileSystemDriver? _fileSystemDriver;
    private Path _root = new(string.Empty);

    public FileSystemDriverResult Connect(IFileSystemDriver fileSystemDriver, Path address)
    {
        _fileSystemDriver = fileSystemDriver;

        if (_fileSystemDriver.DirectoryExists(address) is false ||
            _fileSystemDriver.IsAbsolutePath(address) is false)
        {
            _fileSystemDriver = null;
            return new FileSystemDriverResult.Failure(InvalidPathMessage);
        }

        _root = address;

        return new FileSystemDriverResult.Success();
    }

    public FileSystemDriverResult Disconnect()
    {
        if (_fileSystemDriver is null)
        {
            return new FileSystemDriverResult.Failure(NotConnectedMessage);
        }

        _fileSystemDriver = null;
        _root = new Path(string.Empty);

        return new FileSystemDriverResult.Success();
    }

    public bool FileExists(Path path)
    {
        if (_fileSystemDriver is null)
        {
            return false;
        }

        Path? pathCandidate = _fileSystemDriver.FindAbsolutePath(_root, path);

        return pathCandidate is not null && _fileSystemDriver.FileExists(pathCandidate);
    }

    public bool DirectoryExists(Path path)
    {
        if (_fileSystemDriver is null)
        {
            return false;
        }

        Path? pathCandidate = _fileSystemDriver.FindAbsolutePath(_root, path);

        return pathCandidate is not null && _fileSystemDriver.DirectoryExists(pathCandidate);
    }

    public FileSystemDriverResult ChangeDirectory(Path path)
    {
        if (_fileSystemDriver is null)
        {
            return new FileSystemDriverResult.Failure(NotConnectedMessage);
        }

        Path? pathCandidate = _fileSystemDriver.FindAbsolutePath(_root, path);

        if (pathCandidate is null)
        {
            return new FileSystemDriverResult.Failure(InvalidPathMessage);
        }

        _root = pathCandidate;

        return new FileSystemDriverResult.Success();
    }

    public FileSystemDriverResult CopyFile(Path source, Path destination)
    {
        if (_fileSystemDriver is null)
        {
            return new FileSystemDriverResult.Failure(NotConnectedMessage);
        }

        Path? sourceCandidate = _fileSystemDriver.FindAbsolutePath(_root, source);
        Path? destinationCandidate = _fileSystemDriver.FindAbsolutePath(_root, destination);

        if (sourceCandidate is null || destinationCandidate is null)
        {
            return new FileSystemDriverResult.Failure(InvalidPathMessage);
        }

        return _fileSystemDriver.CopyFile(sourceCandidate, destinationCandidate);
    }

    public FileSystemDriverResult DeleteFile(Path path)
    {
        if (_fileSystemDriver is null)
        {
            return new FileSystemDriverResult.Failure(NotConnectedMessage);
        }

        Path? pathCandidate = _fileSystemDriver.FindAbsolutePath(_root, path);

        return pathCandidate is null
            ? new FileSystemDriverResult.Failure(InvalidPathMessage)
            : _fileSystemDriver.DeleteFile(pathCandidate);
    }

    public FileSystemDriverResult MoveFile(Path source, Path destination)
    {
        if (_fileSystemDriver is null)
        {
            return new FileSystemDriverResult.Failure(NotConnectedMessage);
        }

        Path? sourceCandidate = _fileSystemDriver.FindAbsolutePath(_root, source);
        Path? destinationCandidate = _fileSystemDriver.FindAbsolutePath(_root, destination);

        if (sourceCandidate is null || destinationCandidate is null)
        {
            return new FileSystemDriverResult.Failure(InvalidPathMessage);
        }

        return _fileSystemDriver.MoveFile(sourceCandidate, destinationCandidate);
    }

    public FileSystemDriverResult RenameFile(Path path, string fileName)
    {
        if (_fileSystemDriver is null)
        {
            return new FileSystemDriverResult.Failure(NotConnectedMessage);
        }

        Path? pathCandidate = _fileSystemDriver.FindAbsolutePath(_root, path);

        return pathCandidate is null
            ? new FileSystemDriverResult.Failure(InvalidPathMessage)
            : _fileSystemDriver.RenameFile(pathCandidate, fileName);
    }

    public FileDataResult ReadFileData(Path path)
    {
        if (_fileSystemDriver is null)
        {
            return new FileDataResult.Failure(NotConnectedMessage);
        }

        Path? pathCandidate = _fileSystemDriver.FindAbsolutePath(_root, path);

        return pathCandidate is null
            ? new FileDataResult.Failure(InvalidPathMessage)
            : _fileSystemDriver.ReadFileData(path);
    }

    public FileSystemSubtreeResult GetDirectories(int depth)
    {
        return _fileSystemDriver is null
            ? new FileSystemSubtreeResult.Failure(NotConnectedMessage)
            : _fileSystemDriver.GetSubtree(_root, depth);
    }
}