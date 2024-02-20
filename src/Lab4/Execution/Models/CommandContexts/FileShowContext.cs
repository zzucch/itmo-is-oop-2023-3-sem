using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.Parameters;
using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;

[GenerateBuilder]
public partial record FileShowContext(
    IDisplayDriver DisplayDriver,
    IDisplayDriver ShowDisplayDriver,
    Path Path);