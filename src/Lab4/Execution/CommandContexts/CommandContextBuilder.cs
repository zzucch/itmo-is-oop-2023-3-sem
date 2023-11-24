using Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.FileSystemDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.CommandContexts;

public class CommandContextBuilder : ICommandContextBuilder
{
    private IFileSystemDriver? _fileSystemDriver;
    private IDisplayDriver? _displayDriver;
    private Path? _path;
    private Path? _sourcePath;
    private Path? _destinationPath;
    private TreeListParameters? _treeListParameters;
    private string? _fileName;
    private ICommand? _command;
    private int _depth = 1;

    public ICommandContextBuilder WithFileSystemDriver(IFileSystemDriver driver)
    {
        _fileSystemDriver = driver;
        return this;
    }

    public ICommandContextBuilder WithDisplayDriver(IDisplayDriver driver)
    {
        _displayDriver = driver;
        return this;
    }

    public ICommandContextBuilder WithPath(Path path)
    {
        _path = path;
        return this;
    }

    public ICommandContextBuilder WithSourcePath(Path path)
    {
        _sourcePath = path;
        return this;
    }

    public ICommandContextBuilder WithDestinationPath(Path path)
    {
        _destinationPath = path;
        return this;
    }

    public ICommandContextBuilder WithTreeListParameters(TreeListParameters parameters)
    {
        _treeListParameters = parameters;
        return this;
    }

    public ICommandContextBuilder WithFileName(string name)
    {
        _fileName = name;
        return this;
    }

    public ICommandContextBuilder WithDepth(int depth)
    {
        _depth = depth;
        return this;
    }

    public ICommandContextBuilder WithCommand(ICommand command)
    {
        _command = command;
        return this;
    }

    public CommandContext Build()
    {
        return new CommandContext(
            _command,
            _fileSystemDriver,
            _displayDriver,
            _path,
            _sourcePath,
            _destinationPath,
            _treeListParameters ?? new TreeListParameters(' ', ' ', ' '),
            _fileName,
            _depth);
    }
}