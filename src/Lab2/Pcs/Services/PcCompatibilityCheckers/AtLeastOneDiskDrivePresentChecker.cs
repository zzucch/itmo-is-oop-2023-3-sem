using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class AtLeastOneDiskDrivePresentChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if ((pc.Hdds.Count > 0 || pc.Ssds.Count > 0) is false)
        {
            return new CompatibilityCheckResult.Failure("no disk drive");
        }

        return new CompatibilityCheckResult.Success();
    }
}