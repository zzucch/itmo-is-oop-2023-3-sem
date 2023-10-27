using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class MotherboardFormFactorAndPcCaseCompatibleChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (pc.PcCase.IsCompatibleWithMotherboardFormFactor(pc.Motherboard.FormFactor))
        {
            return new PcCompatibilityCheckResult.Failure("incompatible motherboard form factor and PC case");
        }

        return new PcCompatibilityCheckResult.Success();
    }
}