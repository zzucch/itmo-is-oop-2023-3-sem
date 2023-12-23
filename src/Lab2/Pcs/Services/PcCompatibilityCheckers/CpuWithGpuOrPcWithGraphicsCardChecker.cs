using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class CpuWithGpuOrPcWithGraphicsCardChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if ((pc.Cpu.IntegratedGraphicsProcessor || pc.GraphicsCard is not null) is false)
        {
            return new CompatibilityCheckResult.Failure("no CPU's IGP or graphics card");
        }

        return new CompatibilityCheckResult.Success();
    }
}