using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class IsMotherboardPciEAmountEnoughChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (Check(pc) is false)
        {
            return new CompatibilityCheckResult.Failure("not enough motherboard PCIe slots");
        }

        return new CompatibilityCheckResult.Success();
    }

    private static bool Check(PcValidationModel pc)
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