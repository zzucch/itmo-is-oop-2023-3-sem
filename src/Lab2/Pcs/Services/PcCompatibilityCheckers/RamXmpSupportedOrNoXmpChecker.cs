using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class RamXmpSupportedOrNoXmpChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (Check(pc) is false)
        {
            return new CompatibilityCheckResult.Failure("no RAM's XMP support");
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

            bool any = ram.Xmps.Where(
                xmp => pc.Cpu.SupportedMemoryFrequencies.Any(
                    i => i == xmp.Frequency)).Any(
                xmp => pc.Motherboard.Chipset.SupportedRamFrequencies.Any(
                    i => i == xmp.Frequency));

            if (any is false)
            {
                return false;
            }
        }

        return true;
    }
}