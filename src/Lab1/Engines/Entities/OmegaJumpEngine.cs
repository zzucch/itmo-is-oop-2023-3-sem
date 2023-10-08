using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class OmegaJumpEngine : JumpEngine, IEngine
{
    public OmegaJumpEngine()
    {
        FuelType = Fuel.GravitonMatter;
        SubspaceTravelDistance = SubspaceTravel.Omega;
    }

    public TravelResult Travel(int lightYear, Environment environment)
    {
        return new TravelResult(
            travelTimeTaken: lightYear / 10,
            travelFuelConsumption: lightYear * double.Log(lightYear));
    }
}