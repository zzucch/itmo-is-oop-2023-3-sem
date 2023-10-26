using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;

public interface IPsuBuilder
{
    IPsuBuilder WithName(PcComponentName name);
    IPsuBuilder WithPeakLoad(PowerConsumption powerConsumption);
    IPsu Build();
}