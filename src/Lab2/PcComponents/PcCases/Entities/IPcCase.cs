using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;

public interface IPcCase : IPcCaseBuilderDirector
{
    public PcCaseDimensions Dimensions { get; }
    public bool IsCompatibleWithMotherboardFormFactor(MotherboardFormFactor formFactor);
}