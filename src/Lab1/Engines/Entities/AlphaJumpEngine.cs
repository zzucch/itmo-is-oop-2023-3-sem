using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class AlphaJumpEngine : JumpEngine, IEngine
{
    public AlphaJumpEngine()
    {
        FuelType = Fuel.GravitonMatter;
        SubspaceTravelLength = SubspaceTravel.Alpha;
    }

    public double FuelPerLightYear(int lightYear)
    {
        return 10 * lightYear;
    }
}