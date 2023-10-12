using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class GammaJumpEngine : IEngine
{
    public GammaJumpEngine()
    {
        SubspaceTravelDistance = 300;
    }

    public TravelResult Travel(int lightYear, Environment environment)
    {
        return new TravelResult(
            travelTimeTaken: lightYear / 10,
            travelFuelConsumption: lightYear * lightYear);
    }
}