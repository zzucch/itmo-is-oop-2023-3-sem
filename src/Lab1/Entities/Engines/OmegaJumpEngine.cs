using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class OmegaJumpEngine : IEngine
{
    public OmegaJumpEngine()
    {
        FuelType = Fuel.GravitonMatter;
        SubspaceTravelDistance = 200;
    }

    public TravelResult Travel(int lightYear, Environment environment)
    {
        return new TravelResult(
            travelTimeTaken: lightYear / 10,
            travelFuelConsumption: lightYear * double.Log(lightYear));
    }
}