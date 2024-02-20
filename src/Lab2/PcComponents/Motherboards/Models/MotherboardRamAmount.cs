using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Models;

public record MotherboardRamAmount
{
    public MotherboardRamAmount(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("motherboard ram slots amount must not be negative");
        }

        Amount = amount;
    }

    public int Amount { get; }
}