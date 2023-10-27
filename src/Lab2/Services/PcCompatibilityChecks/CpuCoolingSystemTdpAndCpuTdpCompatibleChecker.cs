using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class CpuCoolingSystemTdpAndCpuTdpCompatibleChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (pc.CpuCoolingSystem.IsCompatibleWithCpuTdp(pc.Cpu.Tdp) is false)
        {
            return new PcCompatibilityCheckResult.WarrantyDisclaimed("incompatible CPU cooling system and CPU TDP, warranty is disclaimed");
        }

        return new PcCompatibilityCheckResult.Success();
    }
}