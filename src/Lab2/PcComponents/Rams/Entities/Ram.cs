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
    private readonly int _ddrVersion;
    private readonly decimal _powerConsumption;

    public Ram(
        int capacity,
        IEnumerable<JedecProfile> jedecProfile,
        IEnumerable<IXmp> xmp,
        RamFormFactor formFactor,
        int ddrVersion,
        decimal powerConsumption)
    {
        _capacity = capacity;
        _jedecProfile = jedecProfile.ToArray();
        _xmp = xmp.ToArray();
        _formFactor = formFactor;
        _ddrVersion = ddrVersion;
        _powerConsumption = powerConsumption;
    }

    public IRamBuilder Direct(IRamBuilder builder)
    {
        builder
            .WithCapacity(_capacity)
            .WithFormFactor(_formFactor)
            .WithDdrVersion(_ddrVersion)
            .WithPowerConsumption(_powerConsumption);

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