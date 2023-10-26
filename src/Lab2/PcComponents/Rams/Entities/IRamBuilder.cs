using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;

public interface IRamBuilder
{
    IRamBuilder WithCapacity(RamCapacity capacity);
    IRamBuilder AddJedecProfile(JedecProfile jedecProfile);
    IRamBuilder AddXmpProfile(IXmp xmp);
    IRamBuilder WithFormFactor(RamFormFactor formFactor);
    IRamBuilder WithDdrVersion(RamDdrVersion version);
    IRamBuilder WithPowerConsumption(PowerConsumption powerConsumption);
    IRam Build();
}