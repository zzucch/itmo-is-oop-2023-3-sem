using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;

public interface IRamBuilder
{
    IRamBuilder WithCapacity(int gBytes);
    IRamBuilder AddJedecProfile(JedecProfile jedecProfile);
    IRamBuilder AddXmpProfile(IXmp xmp);
    IRamBuilder WithFormFactor(RamFormFactor formFactor);
    IRamBuilder WithDdrVersion(int version);
    IRamBuilder WithPowerConsumption(decimal watts);
    IRam Build();
}