using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

public interface IXmpBuilder
{
    IXmpBuilder WithTimings(RamTimings timings);
    IXmpBuilder WithVoltage(decimal volts);
    IXmpBuilder WithSpeed(int mHz);
    IXmp Build();
}