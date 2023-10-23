namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;

public interface IPsu : IPsuBuilderDirector
{
    public bool IsPowerEnough(int powerConsumption);
    public bool IsPowerRecommended(int powerConsumption);
}