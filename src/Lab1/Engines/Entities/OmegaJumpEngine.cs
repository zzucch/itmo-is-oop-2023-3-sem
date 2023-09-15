using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class OmegaJumpEngine : JumpEngine
{
    public OmegaJumpEngine()
    {
        FuelType = Fuel.GravitonMatter;
        SubspaceTravelLength = SubspaceTravel.Omega;
    }

    public static double FuelPerLightYear(int lightYear)
    {
        return double.Log(lightYear);
    }
}