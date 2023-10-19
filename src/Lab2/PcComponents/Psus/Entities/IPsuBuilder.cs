namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;

public interface IPsuBuilder
{
    IPsuBuilder WithPeakLoad(int watts);
    IPsu Build();
}