using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

public interface IXmpBuilder
{
    IXmpBuilder WithTimings(RamTimings timings);
    IXmpBuilder WithVoltage(XmpVoltage volts);
    IXmpBuilder WithFrequency(RamFrequency frequency);
    IXmp Build();
}