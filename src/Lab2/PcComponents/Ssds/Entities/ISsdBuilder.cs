using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Entities;

public interface ISsdBuilder
{
    ISsdBuilder WithInterface(SsdConnectionInterface connectionInterface);
    ISsdBuilder WithCapacity(int gBytes);
    ISsdBuilder WithSpeed(int mbps);
    ISsdBuilder WithPowerConsumption(PowerConsumption powerConsumption);
    ISsd Build();
}