using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Hdds.Entities;

public interface IHdd : IHddBuilderDirector, IPcComponent
{
    public PowerConsumption PowerConsumption { get; }
}