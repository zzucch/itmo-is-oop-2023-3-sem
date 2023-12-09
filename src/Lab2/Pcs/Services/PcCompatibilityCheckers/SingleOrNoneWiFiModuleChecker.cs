using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class SingleOrNoneWiFiModuleChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (pc.WiFiAdapter is not null && pc.Motherboard.WiFiModule)
        {
            return new CompatibilityCheckResult.Failure("two conflicting Wi-Fi modules");
        }

        return new CompatibilityCheckResult.Success();
    }
}