using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;

public record RamFrequency
{
    public RamFrequency(int kHz)
    {
        if (kHz <= 0)
        {
            throw new ArgumentException("ram frequency must be positive");
        }

        Frequency = kHz;
    }

    public int Frequency { get; }
}