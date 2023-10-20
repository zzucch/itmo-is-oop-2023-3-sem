using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;

public class PcCaseBuilder : IPcCaseBuilder
{
    private readonly List<string> _motherboardFormFactors = new();
    private GraphicsCardDimensions? _maxGraphicsCardDimensions;
    private PcCaseDimensions? _dimensions;

    public IPcCaseBuilder WithMaxGraphicsCardDimensions(GraphicsCardDimensions maxDimensions)
    {
        _maxGraphicsCardDimensions = maxDimensions;
        return this;
    }

    public IPcCaseBuilder AddSupportedMotherboardFormFactors(string formFactor)
    {
        _motherboardFormFactors.Add(formFactor);
        return this;
    }

    public IPcCaseBuilder WithDimensions(PcCaseDimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public IPcCase Build()
    {
        return new PcCase(
            _maxGraphicsCardDimensions ?? throw new ArgumentNullException(nameof(_maxGraphicsCardDimensions)),
            _motherboardFormFactors,
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)));
    }
}