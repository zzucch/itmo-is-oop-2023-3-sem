using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Hdds.Entities;

public interface IHddBuilder
{
    IHddBuilder WithCapacity(int gBytes);
    IHddBuilder WithSpeed(int rpm);
    IHddBuilder WithPowerConsumption(PowerConsumption powerConsumption);
    IHdd Build();
}