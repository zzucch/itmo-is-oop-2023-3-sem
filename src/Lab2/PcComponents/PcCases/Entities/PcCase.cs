using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;

public class PcCase : IPcCase
{
    private readonly GraphicsCardDimensions _maxGraphicsCardDimensions;
    private readonly IReadOnlyList<string> _motherboardFormFactors;
    private readonly PcCaseDimensions _dimensions;

    internal PcCase(
        GraphicsCardDimensions maxGraphicsCardDimensions,
        IEnumerable<string> motherboardFormFactors,
        PcCaseDimensions dimensions)
    {
        _maxGraphicsCardDimensions = maxGraphicsCardDimensions;
        _motherboardFormFactors = motherboardFormFactors.ToArray();
        _dimensions = dimensions;
    }

    public IPcCaseBuilder Direct(IPcCaseBuilder builder)
    {
        builder
            .WithMaxGraphicsCardDimensions(_maxGraphicsCardDimensions)
            .WithDimensions(_dimensions);

        foreach (string formFactor in _motherboardFormFactors)
        {
            builder.AddSupportedMotherboardFormFactors(formFactor);
        }

        return builder;
    }
}