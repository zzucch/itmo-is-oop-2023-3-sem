using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;

public record RamCapacity
{
    public RamCapacity(int gBytes)
    {
        if (gBytes <= 0)
        {
            throw new ArgumentException("ram capacity must be positive");
        }

        Capacity = gBytes;
    }

    public int Capacity { get; }
}