namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;

public class Psu : IPsu
{
    private const double RecommendedPowerMarginCoefficient = 1.2;
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

    public bool IsPowerEnough(int powerConsumption)
    {
        return _peakLoad >= powerConsumption;
    }

    public bool IsPowerRecommended(int powerConsumption)
    {
        return _peakLoad >= powerConsumption * RecommendedPowerMarginCoefficient;
    }
}