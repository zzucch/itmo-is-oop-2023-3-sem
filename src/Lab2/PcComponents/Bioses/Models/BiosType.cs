using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Models;

public record BiosType
{
    public BiosType(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException("bios type must not be empty");
        }

        Type = type;
    }

    public string Type { get; }
}