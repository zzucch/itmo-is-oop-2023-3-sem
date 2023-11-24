using Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.FileSystemDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.CommandContexts;

public interface ICommandContextBuilder
{
    ICommandContextBuilder WithFileSystemDriver(IFileSystemDriver driver);
    ICommandContextBuilder WithDisplayDriver(IDisplayDriver driver);
    ICommandContextBuilder WithPath(Path path);
    ICommandContextBuilder WithSourcePath(Path path);
    ICommandContextBuilder WithDestinationPath(Path path);
    ICommandContextBuilder WithTreeListParameters(TreeListParameters parameters);
    ICommandContextBuilder WithFileName(string name);
    ICommandContextBuilder WithDepth(int depth);
    ICommandContextBuilder WithCommand(ICommand command);
    CommandContext Build();
}