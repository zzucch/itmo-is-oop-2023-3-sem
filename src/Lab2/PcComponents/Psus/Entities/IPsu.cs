using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;

public interface IPsu : IPsuBuilderDirector, IPcComponent
{
    public bool IsPowerEnough(PowerConsumption powerConsumption);
    public bool IsPowerRecommended(PowerConsumption powerConsumption);
}