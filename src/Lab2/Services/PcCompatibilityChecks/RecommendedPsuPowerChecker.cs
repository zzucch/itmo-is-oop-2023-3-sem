using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class RecommendedPsuPowerChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        PowerConsumption allPowerConsumption = GetAllPowerConsumption(pc);

        if (pc.Psu.IsPowerRecommended(allPowerConsumption))
        {
            return new PcCompatibilityCheckResult.Success();
        }

        if (pc.Psu.IsPowerEnough(allPowerConsumption))
        {
            return new PcCompatibilityCheckResult.WarrantyDisclaimed("PSU power is below recommended, warranty is disclaimed");
        }

        return new PcCompatibilityCheckResult.Failure("PSU power is below needed");
    }

    private static PowerConsumption GetAllPowerConsumption(IPc pc)
    {
        decimal powerConsumption = decimal.Zero;

        powerConsumption += pc.Cpu.PowerConsumption.PowerConsumed;

        if (pc.GraphicsCard != null)
        {
            powerConsumption += pc.GraphicsCard.PowerConsumption.PowerConsumed;
        }

        if (pc.WiFiAdapter != null)
        {
            powerConsumption += pc.WiFiAdapter.PowerConsumption.PowerConsumed;
        }

        powerConsumption += pc.Hdds.Sum(hdd => hdd.PowerConsumption.PowerConsumed);
        powerConsumption += pc.Ssds.Sum(ssd => ssd.PowerConsumption.PowerConsumed);
        powerConsumption += decimal.ToInt32(decimal.Ceiling(pc.Rams.Sum(ram => ram.PowerConsumption.PowerConsumed)));

        return new PowerConsumption(powerConsumption);
    }
}