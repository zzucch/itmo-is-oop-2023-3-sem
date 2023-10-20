using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;

public class PsuBuilder : IPsuBuilder
{
    private int? _peakLoad;

    public IPsuBuilder WithPeakLoad(int watts)
    {
        _peakLoad = watts;
        return this;
    }

    public IPsu Build()
    {
        return new Psu(_peakLoad ?? throw new ArgumentNullException(nameof(_peakLoad)));
    }
}