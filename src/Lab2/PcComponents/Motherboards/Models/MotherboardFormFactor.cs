using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Models;

public record MotherboardFormFactor
{
    public MotherboardFormFactor(string formFactor)
    {
        if (string.IsNullOrWhiteSpace(formFactor))
        {
            throw new ArgumentException("motherboard form factor must be valid");
        }

        FormFactor = formFactor;
    }

    public string FormFactor { get; }
}