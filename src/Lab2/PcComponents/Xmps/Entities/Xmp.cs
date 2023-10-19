using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

public class Xmp : IXmp
{
    private readonly RamTimings _timings;
    private readonly decimal _voltage;
    private readonly int _frequency;

    public Xmp(RamTimings timings, decimal voltage, int frequency)
    {
        _timings = timings;
        _voltage = voltage;
        _frequency = frequency;
    }

    public IXmpBuilder Direct(IXmpBuilder builder)
    {
        builder
            .WithTimings(_timings)
            .WithVoltage(_voltage)
            .WithFrequency(_frequency);

        return builder;
    }
}