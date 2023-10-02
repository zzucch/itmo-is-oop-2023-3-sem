using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class OmegaJumpEngine : JumpEngine, IEngine
{
    public OmegaJumpEngine()
    {
        FuelType = Fuel.GravitonMatter;
        SubspaceTravelLength = SubspaceTravel.Omega;
    }

    public double FuelPerLightYear(int lightYear)
    {
        return lightYear * double.Log(lightYear);
    }
}