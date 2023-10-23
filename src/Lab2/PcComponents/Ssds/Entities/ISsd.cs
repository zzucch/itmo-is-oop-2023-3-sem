using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Entities;

public interface ISsd : ISsdBuilderDirector
{
    public int PowerConsumption { get; }
    public SsdConnectionInterface ConnectionInterface { get; }
}