using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class IsMotherboardPciEAmountEnoughChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (Check(pc) is false)
        {
            return new PcCompatibilityCheckResult.Failure("not enough motherboard PCIe slots");
        }

        return new PcCompatibilityCheckResult.Success();
    }

    private static bool Check(IPc pc)
    {
        int pciECount = 0;

        if (pc.GraphicsCard is not null)
        {
            pciECount++;
        }

        if (pc.WiFiAdapter is not null)
        {
            pciECount++;
        }

        pciECount += pc.Ssds.Count(ssd => ssd.ConnectionInterface is SsdConnectionInterface.PciE);

        return pc.Motherboard.PciEAmount.Amount >= pciECount;
    }
}