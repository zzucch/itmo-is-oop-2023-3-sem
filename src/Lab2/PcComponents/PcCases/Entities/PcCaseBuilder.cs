using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;

public class PcCaseBuilder : IPcCaseBuilder
{
    private readonly List<MotherboardFormFactor> _motherboardFormFactors = new();
    private PcComponentName? _name;
    private PcCaseDimensions? _dimensions;

    public IPcCaseBuilder WithName(PcComponentName name)
    {
        _name = name;
        return this;
    }

    public IPcCaseBuilder AddSupportedMotherboardFormFactors(MotherboardFormFactor formFactor)
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
            _motherboardFormFactors,
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}