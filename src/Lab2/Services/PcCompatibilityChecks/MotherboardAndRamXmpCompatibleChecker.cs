using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class MotherboardAndRamXmpCompatibleChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (Check(pc))
        {
            return new PcCompatibilityCheckResult.Failure("incompatible motherboard and RAM XMP");
        }

        return new PcCompatibilityCheckResult.Success();
    }

    private static bool Check(IPc pc)
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