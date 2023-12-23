using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;

public record Tdp
{
    public Tdp(int watts)
    {
        if (watts <= 0)
        {
            throw new ArgumentException("tdp must be positive");
        }

        Watts = watts;
    }

    public int Watts { get; }
}