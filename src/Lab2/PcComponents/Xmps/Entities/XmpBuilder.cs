using System;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

public class XmpBuilder : IXmpBuilder
{
    private RamTimings? _timings;
    private XmpVoltage? _voltage;
    private RamFrequency? _frequency;

    public IXmpBuilder WithTimings(RamTimings timings)
    {
        _timings = timings;
        return this;
    }

    public IXmpBuilder WithVoltage(XmpVoltage volts)
    {
        _voltage = volts;
        return this;
    }

    public IXmpBuilder WithFrequency(RamFrequency frequency)
    {
        _frequency = frequency;
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