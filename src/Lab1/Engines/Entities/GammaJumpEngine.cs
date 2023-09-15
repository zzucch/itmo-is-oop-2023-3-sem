using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

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