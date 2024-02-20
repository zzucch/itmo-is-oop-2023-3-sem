using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;

public record CpuCoreSpeed
{
    public CpuCoreSpeed(int mHz)
    {
        if (mHz <= 0)
        {
            throw new ArgumentException("core speed must be positive number");
        }

        MHz = mHz;
    }

    public int MHz { get; }
}