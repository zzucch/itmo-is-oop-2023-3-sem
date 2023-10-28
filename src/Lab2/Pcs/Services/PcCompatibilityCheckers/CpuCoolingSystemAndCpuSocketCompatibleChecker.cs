using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class CpuCoolingSystemAndCpuSocketCompatibleChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (pc.CpuCoolingSystem.IsCompatibleWithCpuSocket(pc.Cpu.Socket) is false)
        {
            return new CompatibilityCheckResult.Failure("incompatible CPU cooling system and CPU socket");
        }

        return new CompatibilityCheckResult.Success();
    }
}