using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;

public class BiosBuilder : IBiosBuilder
{
    private readonly List<ICpu> _cpus = new();
    private string? _type;
    private string? _version;

    public IBiosBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public IBiosBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public IBiosBuilder AddSupportedCpu(ICpu cpu)
    {
        _cpus.Add(cpu);
        return this;
    }

    public IBios Build()
    {
        return new Bios(
            _type ?? throw new ArgumentNullException(nameof(_type)),
            _version ?? throw new ArgumentNullException(nameof(_version)),
            _cpus);
    }
}