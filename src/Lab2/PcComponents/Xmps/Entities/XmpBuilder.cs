using System;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

public class XmpBuilder : IXmpBuilder
{
    private RamTimings? _timings;
    private decimal? _voltage;
    private int? _frequency;

    public IXmpBuilder WithTimings(RamTimings timings)
    {
        _timings = timings;
        return this;
    }

    public IXmpBuilder WithVoltage(decimal volts)
    {
        _voltage = volts;
        return this;
    }

    public IXmpBuilder WithFrequency(int mHz)
    {
        _frequency = mHz;
        return this;
    }

    public IXmp Build()
    {
        return new Xmp(
            _timings ?? throw new ArgumentNullException(nameof(_timings)),
            _voltage ?? throw new ArgumentNullException(nameof(_voltage)),
            _frequency ?? throw new ArgumentNullException(nameof(_frequency)));
    }
}