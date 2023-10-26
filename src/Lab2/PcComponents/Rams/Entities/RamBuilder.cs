using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;

public class RamBuilder : IRamBuilder
{
    private readonly List<JedecProfile> _jedecProfiles = new();
    private readonly List<IXmp> _xmps = new();
    private PcComponentName? _name;
    private RamCapacity? _capacity;
    private RamFormFactor? _formFactor;
    private RamDdrVersion? _ddrVersion;
    private PowerConsumption? _powerConsumption;

    public IRamBuilder WithName(PcComponentName name)
    {
        _name = name;
        return this;
    }

    public IRamBuilder WithCapacity(RamCapacity capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IRamBuilder AddJedecProfile(JedecProfile jedecProfile)
    {
        _jedecProfiles.Add(jedecProfile);
        return this;
    }

    public IRamBuilder AddXmpProfile(IXmp xmp)
    {
        _xmps.Add(xmp);
        return this;
    }

    public IRamBuilder WithFormFactor(RamFormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRamBuilder WithDdrVersion(RamDdrVersion version)
    {
        _ddrVersion = version;
        return this;
    }

    public IRamBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IRam Build()
    {
        return new Ram(
            _capacity ?? throw new ArgumentNullException(nameof(_capacity)),
            _jedecProfiles,
            _xmps,
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _ddrVersion ?? throw new ArgumentNullException(nameof(_ddrVersion)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}