using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;

public record CpuCoreAmount
{
    public CpuCoreAmount(int coreAmount)
    {
        if (coreAmount <= 0)
        {
            throw new ArgumentException("cpu speed amount must be positive");
        }

        CoreAmount = coreAmount;
    }

    public int CoreAmount { get; }
}