using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;

public class Bios : IBios
{
    private readonly BiosType _type;
    private readonly BiosVersion _version;
    private readonly IReadOnlyList<ICpu> _cpus;

    internal Bios(BiosType type, BiosVersion version, IEnumerable<ICpu> cpus)
    {
        _type = type;
        _version = version;
        _cpus = cpus.ToArray();
    }

    public IBiosBuilder Direct(IBiosBuilder builder)
    {
        builder
            .WithType(_type)
            .WithVersion(_version);

        foreach (ICpu cpu in _cpus)
        {
            builder.AddSupportedCpu(cpu);
        }

        return builder;
    }

    public bool IsCompatibleWithCpu(ICpu cpu)
    {
        return _cpus.Contains(cpu);
    }
}