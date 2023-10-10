using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class AlphaJumpEngine : JumpEngine, IEngine
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