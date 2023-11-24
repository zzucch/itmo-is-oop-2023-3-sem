using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;
using Path = Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.FileSystemDrivers;

public class LocalFileSystemDriver : IFileSystemDriver
{
    private const string PathIsNotAbsoluteMessage = "Path is not absolute";
    private const string DisconnectedMessage = "Cannot be executed, connect to file system first";
    private const string SourceNonExistentMessage = "Source file does not exist";
    private const string SourceAlreadyExistsMessage = "Source file already exists";
    private const string DestinationAlreadyExistsMessage = "Destination file already exists";
    private Path? _currentPath;

    public FileSystemDriverResult Connect(Path address)
    {
        if (System.IO.Path.IsPathFullyQualified(address.Value) is false)
        {
            return new FileSystemDriverResult.Failure(PathIsNotAbsoluteMessage);
        }

        _currentPath = address;

        return new FileSystemDriverResult.Success();
    }

    public FileSystemDriverResult Disconnect()
    {
        if (_currentPath is null)
        {
            return new FileSystemDriverResult.Failure(DisconnectedMessage);
        }

        _currentPath = null;

        return new FileSystemDriverResult.Success();
    }

    public FileSystemDriverResult ChangeDirectory(Path path)
    {
        if (_currentPath is null)
        {
            return new FileSystemDriverResult.Failure(DisconnectedMessage);
        }

        var absolute = new Path(path.Value);
        if (System.IO.Path.IsPathFullyQualified(path.Value) is false)
        {
            absolute = new Path(System.IO.Path.Combine(_currentPath.Value, absolute.Value));
        }

        _currentPath = absolute;

        return new FileSystemDriverResult.Success();
    }

    public FileDataResult ReadFileData(Path path)
    {
        if (_currentPath is null)
        {
            return new FileDataResult.Failure(DisconnectedMessage);
        }

        var absolute = new Path(path.Value);
        if (System.IO.Path.IsPathFullyQualified(path.Value) is false)
        {
            absolute = new Path(System.IO.Path.Combine(_currentPath.Value, absolute.Value));
        }

        return new FileDataResult.Success(File.ReadAllText(absolute.Value));
    }

    public FileSystemDriverResult MoveFile(Path source, Path destination)
    {
        if (_currentPath is null)
        {
            return new FileSystemDriverResult.Failure(DisconnectedMessage);
        }

        var absoluteSource = new Path(source.Value);
        if (System.IO.Path.IsPathFullyQualified(source.Value) is false)
        {
            absoluteSource = new Path(System.IO.Path.Combine(_currentPath.Value, absoluteSource.Value));
        }

        var absoluteDestination = new Path(destination.Value);
        if (System.IO.Path.IsPathFullyQualified(destination.Value) is false)
        {
            absoluteDestination = new Path(System.IO.Path.Combine(_currentPath.Value, absoluteDestination.Value));
        }

        if (File.Exists(absoluteSource.Value) is false)
        {
            return new FileSystemDriverResult.Failure(SourceNonExistentMessage);
        }

        if (File.Exists(absoluteDestination.Value))
        {
            return new FileSystemDriverResult.Failure(DestinationAlreadyExistsMessage);
        }

        File.Move(absoluteSource.Value, absoluteDestination.Value);

        return new FileSystemDriverResult.Success();
    }

    public FileSystemDriverResult CopyFile(Path source, Path destination)
    {
        if (_currentPath is null)
        {
            return new FileSystemDriverResult.Failure(DisconnectedMessage);
        }

        var absoluteSource = new Path(source.Value);
        if (System.IO.Path.IsPathFullyQualified(source.Value) is false)
        {
            absoluteSource = new Path(System.IO.Path.Combine(_currentPath.Value, absoluteSource.Value));
        }

        var absoluteDestination = new Path(destination.Value);
        if (System.IO.Path.IsPathFullyQualified(destination.Value) is false)
        {
            absoluteDestination = new Path(System.IO.Path.Combine(_currentPath.Value, absoluteDestination.Value));
        }

        if (File.Exists(absoluteSource.Value) is false)
        {
            return new FileSystemDriverResult.Failure(SourceNonExistentMessage);
        }

        if (File.Exists(absoluteDestination.Value))
        {
            return new FileSystemDriverResult.Failure(DestinationAlreadyExistsMessage);
        }

        File.Copy(absoluteSource.Value, absoluteDestination.Value);

        return new FileSystemDriverResult.Success();
    }

    public FileSystemDriverResult DeleteFile(Path path)
    {
        if (_currentPath is null)
        {
            return new FileSystemDriverResult.Failure(DisconnectedMessage);
        }

        var absolute = new Path(path.Value);
        if (System.IO.Path.IsPathFullyQualified(path.Value) is false)
        {
            absolute = new Path(System.IO.Path.Combine(_currentPath.Value, absolute.Value));
        }

        if (File.Exists(absolute.Value) is false)
        {
            return new FileSystemDriverResult.Failure(SourceNonExistentMessage);
        }

        File.Delete(absolute.Value);

        return new FileSystemDriverResult.Success();
    }

    public FileSystemDriverResult RenameFile(Path path, string name)
    {
        if (_currentPath is null)
        {
            return new FileSystemDriverResult.Failure(DisconnectedMessage);
        }

        var absoluteSource = new Path(path.Value);
        if (System.IO.Path.IsPathFullyQualified(path.Value) is false)
        {
            absoluteSource = new Path(System.IO.Path.Combine(_currentPath.Value, absoluteSource.Value));
        }

        var absoluteDestination = new Path(System.IO.Path.Combine(
            System.IO.Path.GetDirectoryName(path.Value) ?? string.Empty,
            name));
        if (System.IO.Path.IsPathFullyQualified(absoluteDestination.Value) is false)
        {
            absoluteDestination = new Path(System.IO.Path.Combine(_currentPath.Value, absoluteDestination.Value));
        }

        if (File.Exists(absoluteSource.Value) is false)
        {
            return new FileSystemDriverResult.Failure(SourceNonExistentMessage);
        }

        File.Move(absoluteSource.Value, absoluteDestination.Value);

        return new FileSystemDriverResult.Success();
    }

    public FileSystemDriverResult CreateFile(Path path, string data)
    {
        if (_currentPath is null)
        {
            return new FileSystemDriverResult.Failure(DisconnectedMessage);
        }

        var absolute = new Path(path.Value);
        if (System.IO.Path.IsPathFullyQualified(path.Value) is false)
        {
            absolute = new Path(System.IO.Path.Combine(_currentPath.Value, absolute.Value));
        }

        if (File.Exists(absolute.Value))
        {
            return new FileSystemDriverResult.Failure(SourceAlreadyExistsMessage);
        }

        using (StreamWriter writer = File.CreateText(absolute.Value))
        {
            writer.Write(data);
        }

        return new FileSystemDriverResult.Success();
    }

    public ListFilesResult TreeList(int depth, TreeListParameters parameters)
    {
        if (_currentPath is null)
        {
            return new ListFilesResult.Failure(DisconnectedMessage);
        }

        List<string> list = Traversal(depth, currentDepth: 0, parameters, _currentPath, new List<string>());

        string result = string.Empty;
        list.Reverse();
        result = list.Aggregate(result, (current, s) => current + s + Environment.NewLine);

        return new ListFilesResult.Success(result);
    }

    private static List<string> Traversal(
        int depth,
        int currentDepth,
        TreeListParameters parameters,
        Path path,
        List<string> currentResult)
    {
        if (currentDepth < depth)
        {
            return currentResult;
        }

        if (File.Exists(path.Value))
        {
            currentResult.Add(
                new string(parameters.Indentation, currentDepth) +
                parameters.FileIcon +
                System.IO.Path.GetFileName(path.Value));
        }
        else if (Directory.Exists(path.Value))
        {
            currentResult.Add(
                new string(parameters.Indentation, currentDepth) +
                parameters.DirectoryIcon +
                System.IO.Path.GetDirectoryName(path.Value));
        }

        foreach (string entry in Directory.GetFileSystemEntries(path.Value))
        {
            currentResult = Traversal(
                depth,
                currentDepth: currentDepth + 1,
                parameters,
                new Path(entry),
                currentResult);
        }

        return currentResult;
    }
}