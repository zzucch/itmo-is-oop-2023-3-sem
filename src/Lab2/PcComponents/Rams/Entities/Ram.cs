using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;

public class Ram : IRam
{
    private readonly int _capacity;
    private readonly IReadOnlyList<JedecProfile> _jedecProfile;
    private readonly IReadOnlyList<IXmp> _xmp;
    private readonly RamFormFactor _formFactor;

    internal Ram(
        int capacity,
        IEnumerable<JedecProfile> jedecProfiles,
        IEnumerable<IXmp> xmps,
        RamFormFactor formFactor,
        int ddrVersion,
        decimal powerConsumption)
    {
        _capacity = capacity;
        _jedecProfile = jedecProfiles.ToArray();
        _xmp = xmps.ToArray();
        _formFactor = formFactor;
        DdrVersion = ddrVersion;
        PowerConsumption = powerConsumption;
    }

    public int DdrVersion { get; }
    public decimal PowerConsumption { get; }

    public IRamBuilder Direct(IRamBuilder builder)
    {
        builder
            .WithCapacity(_capacity)
            .WithFormFactor(_formFactor)
            .WithDdrVersion(DdrVersion)
            .WithPowerConsumption(PowerConsumption);

        foreach (JedecProfile profile in _jedecProfile)
        {
            builder.AddJedecProfile(profile);
        }

        foreach (IXmp xmp in _xmp)
        {
            builder.AddXmpProfile(xmp);
        }

        return builder;
    }
}