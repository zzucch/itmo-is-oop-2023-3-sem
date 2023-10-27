using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class MotherboardRamSocketsAmountEnoughChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (pc.Rams.Count <= pc.Motherboard.RamSocketAmount.Amount)
        {
            return new PcCompatibilityCheckResult.Failure("not enough motherboard RAM sockets");
        }

        return new PcCompatibilityCheckResult.Success();
    }
}