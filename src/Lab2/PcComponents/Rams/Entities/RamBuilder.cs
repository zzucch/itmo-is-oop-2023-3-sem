using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;

public class RamBuilder : IRamBuilder
{
    private readonly List<JedecProfile> _jedecProfiles = new();
    private readonly List<IXmp> _xmps = new();
    private int? _capacity;
    private RamFormFactor? _formFactor;
    private int? _ddrVersion;
    private decimal? _powerConsumption;

    public IRamBuilder WithCapacity(int gBytes)
    {
        _capacity = gBytes;
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

    public IRamBuilder WithDdrVersion(int version)
    {
        _ddrVersion = version;
        return this;
    }

    public IRamBuilder WithPowerConsumption(decimal watts)
    {
        _powerConsumption = watts;
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
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}