using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

public class Xmp : IXmp
{
    private readonly RamTimings _timings;
    private readonly decimal _voltage;

    internal Xmp(RamTimings timings, decimal voltage, int frequency)
    {
        _timings = timings;
        _voltage = voltage;
        Frequency = frequency;
    }

    public int Frequency { get; }

    public IXmpBuilder Direct(IXmpBuilder builder)
    {
        builder
            .WithTimings(_timings)
            .WithVoltage(_voltage)
            .WithFrequency(Frequency);

        return builder;
    }
}