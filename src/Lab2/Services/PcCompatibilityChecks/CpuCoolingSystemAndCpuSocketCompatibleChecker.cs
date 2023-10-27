using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class CpuCoolingSystemAndCpuSocketCompatibleChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (pc.CpuCoolingSystem.IsCompatibleWithCpuTdp(pc.Cpu.Tdp))
        {
            return new PcCompatibilityCheckResult.Failure("incompatible CPU cooling system and CPU socket");
        }

        return new PcCompatibilityCheckResult.Success();
    }
}