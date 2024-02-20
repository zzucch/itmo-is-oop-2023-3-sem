using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;

public record RamDdrVersion
{
    public RamDdrVersion(int version)
    {
        if (version <= 0)
        {
            throw new ArgumentException("ram ddr version must be positive");
        }

        DdrVersion = version;
    }

    public int DdrVersion { get; }
}