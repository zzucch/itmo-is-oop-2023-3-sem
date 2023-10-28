using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class MotherboardAndRamDdrVersionCompatibleChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (pc.Rams.All(ram => pc.Motherboard.IsCompatibleWithDdrVersion(ram.DdrVersion)) is false)
        {
            return new CompatibilityCheckResult.Failure("incompatible motherboard and RAM DDR version");
        }

        return new CompatibilityCheckResult.Success();
    }
}