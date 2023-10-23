using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;

public class PcCase : IPcCase
{
    private readonly GraphicsCardDimensions _maxGraphicsCardDimensions;
    private readonly IReadOnlyList<string> _motherboardFormFactors;

    internal PcCase(
        GraphicsCardDimensions maxGraphicsCardDimensions,
        IEnumerable<string> motherboardFormFactors,
        PcCaseDimensions dimensions)
    {
        _maxGraphicsCardDimensions = maxGraphicsCardDimensions;
        _motherboardFormFactors = motherboardFormFactors.ToArray();
        Dimensions = dimensions;
    }

    public PcCaseDimensions Dimensions { get; }

    public IPcCaseBuilder Direct(IPcCaseBuilder builder)
    {
        builder
            .WithMaxGraphicsCardDimensions(_maxGraphicsCardDimensions)
            .WithDimensions(Dimensions);

        foreach (string formFactor in _motherboardFormFactors)
        {
            builder.AddSupportedMotherboardFormFactors(formFactor);
        }

        return builder;
    }

    public bool IsCompatibleWithMotherboardFormFactor(string formFactor)
    {
        return _motherboardFormFactors.Contains(formFactor);
    }
}