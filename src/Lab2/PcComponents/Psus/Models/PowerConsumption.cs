using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

public record PowerConsumption
{
    public PowerConsumption(decimal watts)
    {
        if (watts <= 0)
        {
            throw new ArgumentException("power consumption must be positive");
        }

        PowerConsumed = watts;
    }

    public decimal PowerConsumed { get; }
}