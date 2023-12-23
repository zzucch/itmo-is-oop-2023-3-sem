using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class CpuCoolingSystemTdpAndCpuTdpCompatibleChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (pc.CpuCoolingSystem.IsCompatibleWithCpuTdp(pc.Cpu.Tdp) is false)
        {
            return new CompatibilityCheckResult.WarrantyDisclaimed("incompatible CPU cooling system and CPU TDP, warranty is disclaimed");
        }

        return new CompatibilityCheckResult.Success();
    }
}