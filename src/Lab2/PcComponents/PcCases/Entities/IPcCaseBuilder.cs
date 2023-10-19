using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;

public interface IPcCaseBuilder
{
    IPcCaseBuilder WithMaxGraphicsCardDimensions(int height, int length);
    IPcCaseBuilder AddSupportedMotherboardFormFactors();
    IPcCaseBuilder WithDimensions(PcCaseDimensions dimensions);
    IPcCase Build();
}