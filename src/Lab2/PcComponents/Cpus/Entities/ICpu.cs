using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

public interface ICpu : ICpuBuilderDirector
{
    public int Tdp { get; }
    public string Socket { get; }
    public int PowerConsumption { get; }
    public bool IntegratedGraphicsProcessor { get; }
    public IReadOnlyList<int> SupportedMemoryFrequencies { get; }
}