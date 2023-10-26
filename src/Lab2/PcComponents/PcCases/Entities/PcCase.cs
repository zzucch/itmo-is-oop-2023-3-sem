using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;

public class PcCase : IPcCase
{
    private readonly IReadOnlyList<MotherboardFormFactor> _motherboardFormFactors;

    internal PcCase(
        IEnumerable<MotherboardFormFactor> motherboardFormFactors,
        PcCaseDimensions dimensions)
    {
        _motherboardFormFactors = motherboardFormFactors.ToArray();
        Dimensions = dimensions;
    }

    public PcCaseDimensions Dimensions { get; }

    public IPcCaseBuilder Direct(IPcCaseBuilder builder)
    {
        builder
            .WithDimensions(Dimensions);

        foreach (MotherboardFormFactor formFactor in _motherboardFormFactors)
        {
            builder.AddSupportedMotherboardFormFactors(formFactor);
        }

        return builder;
    }

    public bool IsCompatibleWithMotherboardFormFactor(MotherboardFormFactor formFactor)
    {
        return _motherboardFormFactors.Contains(formFactor);
    }
}