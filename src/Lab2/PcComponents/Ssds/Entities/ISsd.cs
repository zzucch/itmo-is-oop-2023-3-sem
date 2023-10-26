using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Entities;

public interface ISsd : ISsdBuilderDirector
{
    public PowerConsumption PowerConsumption { get; }
    public SsdConnectionInterface ConnectionInterface { get; }
}