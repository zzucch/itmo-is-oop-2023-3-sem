using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Models;

public record MotherboardPciEAmount
{
    public MotherboardPciEAmount(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("motherboard pci-e amount must not be negative");
        }

        Amount = amount;
    }

    public int Amount { get; }
}