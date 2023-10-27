using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class BiosAndCpuCompatibleChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (pc.Motherboard.Bios.IsCompatibleWithCpu(pc.Cpu))
        {
            return new PcCompatibilityCheckResult.Failure("incompatible BIOS and CPU");
        }

        return new PcCompatibilityCheckResult.Success();
    }
}