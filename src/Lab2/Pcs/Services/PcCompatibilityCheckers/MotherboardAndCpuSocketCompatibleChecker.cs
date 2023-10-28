using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class MotherboardAndCpuSocketCompatibleChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (pc.Motherboard.IsCompatibleWithSocket(pc.Cpu.Socket) is false)
        {
            return new CompatibilityCheckResult.Failure("incompatible motherboard CPU socket and CPU");
        }

        return new CompatibilityCheckResult.Success();
    }
}