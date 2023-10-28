using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class CpuCoolingSystemSizeAndPcCaseCompatibleChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (pc.PcCase.Dimensions.MaxCpuCoolingSystemUnitHeight >= pc.CpuCoolingSystem.Dimensions.Height
            && pc.PcCase.Dimensions.MaxCpuCoolingSystemUnitLength >= pc.CpuCoolingSystem.Dimensions.Length
            && pc.PcCase.Dimensions.MaxCpuCoolingSystemUnitWidth >= pc.CpuCoolingSystem.Dimensions.Width is false)
        {
            return new CompatibilityCheckResult.Failure("incompatible CPU cooling system and PC case");
        }

        return new CompatibilityCheckResult.Success();
    }
}