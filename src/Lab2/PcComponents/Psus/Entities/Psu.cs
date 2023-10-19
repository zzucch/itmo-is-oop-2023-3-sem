namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;

public class Psu : IPsu
{
    private readonly int _peakLoad;

    internal Psu(int peakLoad)
    {
        _peakLoad = peakLoad;
    }

    public IPsuBuilder Direct(IPsuBuilder builder)
    {
        builder.WithPeakLoad(_peakLoad);

        return builder;
    }
}