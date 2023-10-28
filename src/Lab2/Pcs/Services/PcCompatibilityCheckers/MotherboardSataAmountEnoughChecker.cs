using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class MotherboardSataAmountEnoughChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (Check(pc) is false)
        {
            return new CompatibilityCheckResult.Failure("not enough motherboard SATA slots");
        }

        return new CompatibilityCheckResult.Success();
    }

    private static bool Check(PcValidationModel pc)
    {
        int sataCount = 0;

        sataCount += pc.Hdds.Count;
        sataCount += pc.Ssds.Count(ssd => ssd.ConnectionInterface is SsdConnectionInterface.Sata);

        return pc.Motherboard.SataAmount.Amount >= sataCount;
    }
}