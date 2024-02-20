using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class MotherboardAndRamProfileCompatibleChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (Check(pc) is false)
        {
            return new CompatibilityCheckResult.Failure("incompatible RAM and motherboard");
        }

        return new CompatibilityCheckResult.Success();
    }

    private static bool Check(PcValidationModel pc)
    {
        return pc.Rams.Any(ram => ram.JedecProfiles.Any(
            profile => pc.Motherboard.Chipset.SupportedRamFrequencies.Any(
                i => i == profile.Frequency)));
    }
}