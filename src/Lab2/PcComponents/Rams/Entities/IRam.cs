namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;

public interface IRam : IRamBuilderDirector
{
    public int DdrVersion { get; }
    public decimal PowerConsumption { get; }
}