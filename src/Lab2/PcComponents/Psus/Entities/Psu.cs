using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;

public class Psu : IPsu
{
    private static readonly decimal RecommendedPowerMarginCoefficient = new(1.2);
    private readonly PowerConsumption _peakLoad;

    internal Psu(PowerConsumption peakLoad, PcComponentName name)
    {
        _peakLoad = peakLoad;
        Name = name;
    }

    public PcComponentName Name { get; }

    public IPsuBuilder Direct(IPsuBuilder builder)
    {
        builder.WithPeakLoad(_peakLoad);

        return builder;
    }

    public bool IsPowerEnough(PowerConsumption powerConsumption)
    {
        return _peakLoad.PowerConsumed >= powerConsumption.PowerConsumed;
    }

    public bool IsPowerRecommended(PowerConsumption powerConsumption)
    {
        return _peakLoad.PowerConsumed >= powerConsumption.PowerConsumed * RecommendedPowerMarginCoefficient;
    }
}