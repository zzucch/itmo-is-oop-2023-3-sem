using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineE : IEngine
{
    public Fuel FuelType { get; } = Fuel.ActivePlasma;

    public TravelResult Travel(int lightYear, Environment environment)
    {
        return new TravelResult(
            travelTimeTaken: lightYear / 10,
            travelFuelConsumption: double.Exp(lightYear));
    }
}