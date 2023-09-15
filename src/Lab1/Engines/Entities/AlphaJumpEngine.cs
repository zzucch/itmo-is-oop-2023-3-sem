using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class AlphaJumpEngine : JumpEngine
{
    public AlphaJumpEngine()
    {
        FuelType = Fuel.GravitonMatter;
        SubspaceTravelLength = SubspaceTravel.Alpha;
    }

    public static double FuelPerLightYear(int lightYear)
    {
        return 10 * lightYear;
    }
}