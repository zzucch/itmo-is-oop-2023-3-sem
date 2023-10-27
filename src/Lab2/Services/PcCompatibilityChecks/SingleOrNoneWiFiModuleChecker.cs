using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class SingleOrNoneWiFiModuleChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if ((pc.WiFiAdapter is not null && pc.Motherboard.WiFiModule) is false)
        {
            return new PcCompatibilityCheckResult.Failure("two conflicting Wi-Fi modules");
        }

        return new PcCompatibilityCheckResult.Success();
    }
}