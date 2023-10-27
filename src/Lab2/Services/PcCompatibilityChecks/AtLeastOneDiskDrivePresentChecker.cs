using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class AtLeastOneDiskDrivePresentChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (pc.Hdds.Count > 0 || pc.Ssds.Count > 0)
        {
            return new PcCompatibilityCheckResult.Failure("no disk drive");
        }

        return new PcCompatibilityCheckResult.Success();
    }
}