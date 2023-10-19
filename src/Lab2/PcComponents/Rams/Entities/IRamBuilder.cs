using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;

public interface IRamBuilder
{
    IRamBuilder WithCapacity(int gBytes);
    IRamBuilder AddJedecProfile(int kHz, RamTimings timings);
    IRamBuilder AddXmpProfile(IXmp xmp);
    IRamBuilder WithFormFactor();
    IRamBuilder WithDdrVersion(int version);
    IRamBuilder WithPowerConsumption(decimal watts);
    IRam Build();
}