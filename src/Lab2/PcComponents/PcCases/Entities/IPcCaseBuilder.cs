using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;

public interface IPcCaseBuilder
{
    IPcCaseBuilder WithName(PcComponentName name);
    IPcCaseBuilder AddSupportedMotherboardFormFactors(MotherboardFormFactor formFactor);
    IPcCaseBuilder WithDimensions(PcCaseDimensions dimensions);
    IPcCase Build();
}