using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

public class Xmp : IXmp
{
    private readonly RamTimings _timings;
    private readonly XmpVoltage _voltage;

    internal Xmp(RamTimings timings, XmpVoltage voltage, RamFrequency frequency)
    {
        _timings = timings;
        _voltage = voltage;
        Frequency = frequency;
    }

    public RamFrequency Frequency { get; }

    public IXmpBuilder Direct(IXmpBuilder builder)
    {
        builder
            .WithTimings(_timings)
            .WithVoltage(_voltage)
            .WithFrequency(Frequency);

        return builder;
    }
}