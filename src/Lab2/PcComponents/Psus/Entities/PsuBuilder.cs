using System;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;

public class PsuBuilder : IPsuBuilder
{
    private PcComponentName? _name;
    private PowerConsumption? _peakLoad;

    public IPsuBuilder WithName(PcComponentName name)
    {
        _name = name;
        return this;
    }

    public IPsuBuilder WithPeakLoad(PowerConsumption powerConsumption)
    {
        _peakLoad = powerConsumption;
        return this;
    }

    public IPsu Build()
    {
        return new Psu(
            _peakLoad ?? throw new ArgumentNullException(nameof(_peakLoad)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}