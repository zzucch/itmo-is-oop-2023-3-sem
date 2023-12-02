using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.FileSystemDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.Parameters;
using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;

[GenerateBuilder]
public partial record ConnectContext(IDisplayDriver DisplayDriver, Path Path, IFileSystemDriver FileSystemDriver);