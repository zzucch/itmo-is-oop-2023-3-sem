using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;
using Path = Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.Parameters.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.FileSystemDrivers;

public class LocalFileSystemDriver : IFileSystemDriver
{
    public bool FileExists(Path path)
    {
        return File.Exists(path.Value);
    }

    public bool DirectoryExists(Path path)
    {
        return Directory.Exists(path.Value);
    }

    public bool IsAbsolutePath(Path path)
    {
        return System.IO.Path.IsPathFullyQualified(path.Value);
    }

    public Path? FindAbsolutePath(Path root, Path path)
    {
        if (IsAbsolutePath(path))
        {
            return path;
        }

        string absoluteCandidate = root.Value + System.IO.Path.DirectorySeparatorChar + path.Value;

        return System.IO.Path.IsPathFullyQualified(absoluteCandidate) is false
            ? null
            : new Path(absoluteCandidate);
    }

    public FileDataResult ReadFileData(Path path)
    {
        try
        {
            string data = File.ReadAllText(path.Value);

            return new FileDataResult.Success(data);
        }
        catch (Exception exception)
        {
            return new FileDataResult.Failure(exception.Message);
        }
    }

    public FileSystemDriverResult MoveFile(Path source, Path destination)
    {
        try
        {
            File.Move(source.Value, destination.Value);
        }
        catch (Exception exception)
        {
            return new FileSystemDriverResult.Failure(exception.Message);
        }

        return new FileSystemDriverResult.Success();
    }

    public FileSystemDriverResult RenameFile(Path source, string fileName)
    {
        try
        {
            string directoryName = System.IO.Path.GetDirectoryName(source.Value) ?? string.Empty;
            string destination = directoryName + System.IO.Path.DirectorySeparatorChar + fileName;

            File.Copy(source.Value, destination);

            File.Delete(source.Value);
        }
        catch (Exception exception)
        {
            return new FileSystemDriverResult.Failure(exception.Message);
        }

        return new FileSystemDriverResult.Success();
    }

    public FileSystemDriverResult CopyFile(Path source, Path destination)
    {
        try
        {
            File.Copy(source.Value, destination.Value);
        }
        catch (Exception exception)
        {
            return new FileSystemDriverResult.Failure(exception.Message);
        }

        return new FileSystemDriverResult.Success();
    }

    public FileSystemDriverResult DeleteFile(Path path)
    {
        try
        {
            File.Delete(path.Value);
        }
        catch (Exception exception)
        {
            return new FileSystemDriverResult.Failure(exception.Message);
        }

        return new FileSystemDriverResult.Success();
    }

    public FileSystemSubtreeResult GetSubtree(Path path, int depth)
    {
        try
        {
            List<TreeElement> list = Traversal(depth, currentDepth: 0, path, new List<TreeElement>());

            list.Reverse();

            return new FileSystemSubtreeResult.Success(list);
        }
        catch (Exception exception)
        {
            return new FileSystemSubtreeResult.Failure(exception.Message);
        }
    }

    private static List<TreeElement> Traversal(
        int depth,
        int currentDepth,
        Path path,
        List<TreeElement> currentResult)
    {
        if (currentDepth < depth)
        {
            return currentResult;
        }

        if (File.Exists(path.Value))
        {
            string name = System.IO.Path.GetFileName(path.Value);

            currentResult.Add(new TreeElement.File(
                name,
                currentDepth));

            return currentResult;
        }

        if (Directory.Exists(path.Value))
        {
            currentResult.Add(new TreeElement.Directory(
                System.IO.Path.GetDirectoryName(path.Value) ?? string.Empty,
                currentDepth));
        }

        foreach (string entry in Directory.GetFileSystemEntries(path.Value))
        {
            currentResult = Traversal(
                depth,
                currentDepth: currentDepth + 1,
                new Path(entry),
                currentResult);
        }

        return currentResult;
    }
}