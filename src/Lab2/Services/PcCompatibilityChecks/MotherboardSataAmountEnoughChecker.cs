using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class MotherboardSataAmountEnoughChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (Check(pc))
        {
            return new PcCompatibilityCheckResult.Failure("not enough motherboard SATA slots");
        }

        return new PcCompatibilityCheckResult.Success();
    }

    private static bool Check(IPc pc)
    {
        int sataCount = 0;

        sataCount += pc.Hdds.Count;
        sataCount += pc.Ssds.Count(ssd => ssd.ConnectionInterface is SsdConnectionInterface.Sata);

        return pc.Motherboard.SataAmount.Amount >= sataCount;
    }
}