using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;

public record GraphicsCardVideoMemory
{
    public GraphicsCardVideoMemory(int gBytes)
    {
        if (gBytes <= 0)
        {
            throw new ArgumentException("graphics card video memory must be positive");
        }

        VideoMemory = gBytes;
    }

    public int VideoMemory { get; }
}