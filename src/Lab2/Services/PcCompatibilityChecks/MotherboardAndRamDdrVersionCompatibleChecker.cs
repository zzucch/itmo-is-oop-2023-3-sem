using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class MotherboardAndRamDdrVersionCompatibleChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (pc.Rams.All(ram => pc.Motherboard.IsCompatibleWithDdrVersion(ram.DdrVersion)) is false)
        {
            return new PcCompatibilityCheckResult.Failure("incompatible motherboard and RAM DDR version");
        }

        return new PcCompatibilityCheckResult.Success();
    }
}