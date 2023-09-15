using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class GammaJumpEngine : JumpEngine, IEngine
{
    public GammaJumpEngine()
    {
        SubspaceTravelLength = SubspaceTravel.Gamma;
    }

    public double FuelPerLightYear(int lightYear)
    {
        return lightYear * lightYear;
    }
}