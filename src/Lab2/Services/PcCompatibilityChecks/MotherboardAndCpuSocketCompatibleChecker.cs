using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class MotherboardAndCpuSocketCompatibleChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (pc.Motherboard.IsCompatibleWithSocket(pc.Cpu.Socket))
        {
            return new PcCompatibilityCheckResult.Failure("incompatible motherboard CPU socket and CPU");
        }

        return new PcCompatibilityCheckResult.Success();
    }
}