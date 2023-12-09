using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class CpuAndRamProfileCompatibleChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (Check(pc) is false)
        {
            return new CompatibilityCheckResult.Failure("incompatible CPU and RAM profile");
        }

        return new CompatibilityCheckResult.Success();
    }

    private static bool Check(PcValidationModel pc)
    {
        return pc.Rams.Any(ram => ram.JedecProfiles.Any(
            profile => pc.Cpu.SupportedMemoryFrequencies.Any(
                i => i == profile.Frequency)));
    }
}