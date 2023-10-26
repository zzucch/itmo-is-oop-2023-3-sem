using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

public interface ICpu : ICpuBuilderDirector, IPcComponent
{
    public Tdp Tdp { get; }
    public CpuSocket Socket { get; }
    public PowerConsumption PowerConsumption { get; }
    public bool IntegratedGraphicsProcessor { get; }
    public IReadOnlyList<RamFrequency> SupportedMemoryFrequencies { get; }
}