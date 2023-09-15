using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class AlphaJumpEngine : JumpEngine
{
    public AlphaJumpEngine()
    {
        FuelType = Fuel.GravitonicMatter;
        SubspaceTravelLength = SubspaceTravel.Alpha;
    }

    public static double FuelPerLightYear(int lightYear)
    {
        return 10 * lightYear;
    }
}