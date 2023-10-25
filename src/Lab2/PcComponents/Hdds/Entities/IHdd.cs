namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Hdds.Entities;

public interface IHdd : IHddBuilderDirector
{
    public int PowerConsumption { get; }
}