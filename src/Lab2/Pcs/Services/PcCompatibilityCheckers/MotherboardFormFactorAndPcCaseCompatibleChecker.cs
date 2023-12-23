using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class MotherboardFormFactorAndPcCaseCompatibleChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (pc.PcCase.IsCompatibleWithMotherboardFormFactor(pc.Motherboard.FormFactor) is false)
        {
            return new CompatibilityCheckResult.Failure("incompatible motherboard form factor and PC case");
        }

        return new CompatibilityCheckResult.Success();
    }
}