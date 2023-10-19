using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;

public interface IPcCaseBuilder
{
    IPcCaseBuilder WithMaxGraphicsCardDimensions(GraphicsCardDimensions maxDimensions);
    IPcCaseBuilder AddSupportedMotherboardFormFactors(string formFactor);
    IPcCaseBuilder WithDimensions(PcCaseDimensions dimensions);
    IPcCase Build();
}