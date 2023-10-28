using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class BiosAndCpuCompatibleChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (pc.Motherboard.Bios.IsCompatibleWithCpu(pc.Cpu) is false)
        {
            return new CompatibilityCheckResult.Failure("incompatible BIOS and CPU");
        }

        return new CompatibilityCheckResult.Success();
    }
}