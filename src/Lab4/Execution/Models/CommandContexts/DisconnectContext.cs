using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;

[GenerateBuilder]
public partial record DisconnectContext(IDisplayDriver DisplayDriver);