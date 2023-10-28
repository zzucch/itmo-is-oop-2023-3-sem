using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class RecommendedPsuPowerChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        PowerConsumption allPowerConsumption = GetAllPowerConsumption(pc);

        if (pc.Psu.IsPowerRecommended(allPowerConsumption))
        {
            return new CompatibilityCheckResult.Success();
        }

        if (pc.Psu.IsPowerEnough(allPowerConsumption))
        {
            return new CompatibilityCheckResult.WarrantyDisclaimed("PSU power is below recommended, warranty is disclaimed");
        }

        return new CompatibilityCheckResult.Failure("PSU power is below needed");
    }

    private static PowerConsumption GetAllPowerConsumption(PcValidationModel pc)
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