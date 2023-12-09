using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class MotherboardRamSocketsAmountEnoughChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (pc.Rams.Count <= pc.Motherboard.RamSocketAmount.Amount is false)
        {
            return new CompatibilityCheckResult.Failure("not enough motherboard RAM sockets");
        }

        return new CompatibilityCheckResult.Success();
    }
}