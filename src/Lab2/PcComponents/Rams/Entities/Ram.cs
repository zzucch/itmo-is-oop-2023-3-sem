using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;

public class Ram : IRam
{
    private readonly RamCapacity _capacity;
    private readonly RamFormFactor _formFactor;

    internal Ram(
        RamCapacity capacity,
        IEnumerable<JedecProfile> jedecProfiles,
        IEnumerable<IXmp> xmps,
        RamFormFactor formFactor,
        RamDdrVersion ddrVersion,
        PowerConsumption powerConsumption)
    {
        _capacity = capacity;
        JedecProfiles = jedecProfiles.ToArray();
        Xmps = xmps.ToArray();
        _formFactor = formFactor;
        DdrVersion = ddrVersion;
        PowerConsumption = powerConsumption;
    }

    public RamDdrVersion DdrVersion { get; }
    public IReadOnlyList<IXmp> Xmps { get; }
    public PowerConsumption PowerConsumption { get; }
    public IReadOnlyList<JedecProfile> JedecProfiles { get; }

    public IRamBuilder Direct(IRamBuilder builder)
    {
        builder
            .WithCapacity(_capacity)
            .WithFormFactor(_formFactor)
            .WithDdrVersion(DdrVersion)
            .WithPowerConsumption(PowerConsumption);

        foreach (JedecProfile profile in JedecProfiles)
        {
            builder.AddJedecProfile(profile);
        }

        foreach (IXmp xmp in Xmps)
        {
            builder.AddXmpProfile(xmp);
        }

        return builder;
    }
}