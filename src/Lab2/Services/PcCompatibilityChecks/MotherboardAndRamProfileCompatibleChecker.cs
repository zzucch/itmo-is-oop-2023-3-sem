using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class MotherboardAndRamProfileCompatibleChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (Check(pc))
        {
            return new PcCompatibilityCheckResult.Failure("incompatible RAM and motherboard");
        }

        return new PcCompatibilityCheckResult.Success();
    }

    private static bool Check(IPc pc)
    {
        return pc.Rams.Any(ram => ram.JedecProfiles.Any(
            profile => pc.Motherboard.Chipset.SupportedRamFrequencies.Any(
                i => i == profile.Frequency)));
    }
}