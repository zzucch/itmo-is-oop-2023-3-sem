using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class CpuWithGpuOrPcWithGraphicsCardChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (pc.Cpu.IntegratedGraphicsProcessor || pc.GraphicsCard is not null)
        {
            return new PcCompatibilityCheckResult.Failure("no CPU's IGP or graphics card");
        }

        return new PcCompatibilityCheckResult.Success();
    }
}