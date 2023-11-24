using Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.FileSystemDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.CommandContexts;

public record CommandContext(
    ICommand? Command,
    IFileSystemDriver? FileSystemDriver,
    IDisplayDriver? DisplayDriver,
    Path? Path,
    Path? SourcePath,
    Path? DestinationPath,
    TreeListParameters TreeListParameters,
    string? FileName,
    int Depth = 1);