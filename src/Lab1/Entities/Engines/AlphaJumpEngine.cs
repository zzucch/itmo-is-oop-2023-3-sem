using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class AlphaJumpEngine : IEngine
{
    public AlphaJumpEngine()
    {
        FuelType = Fuel.GravitonMatter;
        SubspaceTravelDistance = 100;
    }

    public TravelResult Travel(int lightYear, Environment environment)
    {
        return new TravelResult(
            travelTimeTaken: lightYear / 10,
            travelFuelConsumption: 10 * lightYear);
    }
}