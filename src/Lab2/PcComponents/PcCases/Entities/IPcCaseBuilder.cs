using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;

public interface IPcCaseBuilder
{
    IPcCaseBuilder AddSupportedMotherboardFormFactors(string formFactor);
    IPcCaseBuilder WithDimensions(PcCaseDimensions dimensions);
    IPcCase Build();
}