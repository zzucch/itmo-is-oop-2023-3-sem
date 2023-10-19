namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Entities;

public interface ISsdBuilder
{
    ISsdBuilder WithInterface();
    ISsdBuilder WithCapacity(int gBytes);
    ISsdBuilder WithSpeed();
    ISsdBuilder WithPowerConsumption(int watts);
    ISsd Build();
}