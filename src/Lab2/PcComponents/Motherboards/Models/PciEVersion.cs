using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Models;

public record PciEVersion
{
    public PciEVersion(int version)
    {
        if (version <= 0)
        {
            throw new ArgumentException("pci-e version must be positive");
        }

        Version = version;
    }

    public int Version { get; }
}