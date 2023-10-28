using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class MotherboardAndRamXmpCompatibleChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (Check(pc) is false)
        {
            return new CompatibilityCheckResult.Failure("incompatible motherboard and RAM XMP");
        }

        return new CompatibilityCheckResult.Success();
    }

    private static bool Check(PcValidationModel pc)
    {
        foreach (IRam ram in pc.Rams)
        {
            if (ram.Xmps.Count <= 0)
            {
                continue;
            }

            if (pc.Motherboard.Chipset.SupportsXmp is false)
            {
                return false;
            }

            if (ram.Xmps.Any(xmp => pc.Motherboard.Chipset.SupportedRamFrequencies.Any(i => i == xmp.Frequency)) is false)
            {
                return false;
            }
        }

        return true;
    }
}