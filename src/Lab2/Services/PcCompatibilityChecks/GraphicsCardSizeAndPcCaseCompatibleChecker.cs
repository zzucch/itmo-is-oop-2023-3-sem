using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

public class GraphicsCardSizeAndPcCaseCompatibleChecker : IPcCompatibilityChecker
{
    public PcCompatibilityCheckResult CheckCompatibility(IPc pc)
    {
        if (Check(pc))
        {
            return new PcCompatibilityCheckResult.Failure("incompatible graphics card and PC case");
        }

        return new PcCompatibilityCheckResult.Success();
    }

    private static bool Check(IPc pc)
    {
        if (pc.GraphicsCard is null)
        {
            return true;
        }

        return pc.PcCase.Dimensions.GraphicsCardMaxHeight >= pc.GraphicsCard.Dimensions.Height
               && pc.PcCase.Dimensions.Length >= pc.GraphicsCard.Dimensions.Length
               && pc.PcCase.Dimensions.Width >= pc.GraphicsCard.Dimensions.Width;
    }
}