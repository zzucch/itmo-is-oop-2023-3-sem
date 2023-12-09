using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Models;

public record BiosVersion
{
    public BiosVersion(string version)
    {
        if (string.IsNullOrWhiteSpace(version))
        {
            throw new ArgumentException("bios version must not be empty");
        }

        Version = version;
    }

    public string Version { get; }
}