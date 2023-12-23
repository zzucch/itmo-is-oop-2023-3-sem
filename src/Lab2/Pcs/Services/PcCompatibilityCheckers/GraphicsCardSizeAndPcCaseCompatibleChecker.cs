using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public class GraphicsCardSizeAndPcCaseCompatibleChecker : IPcCompatibilityChecker
{
    public CompatibilityCheckResult CheckCompatibility(PcValidationModel pc)
    {
        if (Check(pc) is false)
        {
            return new CompatibilityCheckResult.Failure("incompatible graphics card and PC case");
        }

        return new CompatibilityCheckResult.Success();
    }

    private static bool Check(PcValidationModel pc)
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