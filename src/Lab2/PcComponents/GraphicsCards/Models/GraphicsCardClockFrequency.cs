using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;

public record GraphicsCardClockFrequency
{
    public GraphicsCardClockFrequency(int hertz)
    {
        if (hertz <= 0)
        {
            throw new ArgumentException("graphics card clock frequency must be positive");
        }

        ClockFrequency = hertz;
    }

    public int ClockFrequency { get; }
}