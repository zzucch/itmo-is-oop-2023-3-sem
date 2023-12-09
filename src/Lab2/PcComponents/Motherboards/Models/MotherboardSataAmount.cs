using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Models;

public record MotherboardSataAmount
{
    public MotherboardSataAmount(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("motherboard sata amount must not be negative");
        }

        Amount = amount;
    }

    public int Amount { get; }
}