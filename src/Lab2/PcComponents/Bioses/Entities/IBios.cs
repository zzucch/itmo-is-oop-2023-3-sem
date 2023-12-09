using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;

public interface IBios : IBiosBuilderDirector
{
    public bool IsCompatibleWithCpu(ICpu cpu);
}