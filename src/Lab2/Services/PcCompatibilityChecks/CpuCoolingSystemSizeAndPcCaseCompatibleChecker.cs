using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class CpuCoolingSystemSizeAndPcCaseCompatibleChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (pc.PcCase.Dimensions.MaxCpuCoolingSystemUnitHeight >= pc.CpuCoolingSystem.Dimensions.Height
            && pc.PcCase.Dimensions.MaxCpuCoolingSystemUnitLength >= pc.CpuCoolingSystem.Dimensions.Length
            && pc.PcCase.Dimensions.MaxCpuCoolingSystemUnitWidth >= pc.CpuCoolingSystem.Dimensions.Width)
        {
            return new PcCompatibilityCheckResult.Failure("incompatible CPU cooling system and PC case");
        }

        return new PcCompatibilityCheckResult.Success();
    }
}