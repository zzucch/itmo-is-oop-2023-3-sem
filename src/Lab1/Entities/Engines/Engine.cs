using Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class Engine
{
    public Engine(ITravellingStrategy travellingStrategy)
    {
        TravellingStrategy = travellingStrategy;
    }

    private ITravellingStrategy TravellingStrategy { get; }

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType)
    {
        if ((environmentType is EnvironmentType.NitriteNebula && TravellingStrategy is not INegativeAccelerationTolerantStrategy) is false)
        {
            return TravellingStrategy.TryTravel(distanceLightYear, environmentType);
        }

        return new TravelResult(
            Success: false,
            TravelTimeTaken: 0.0,
            FuelTypeConsumed: Fuel.ActivePlasma,
            TravelFuelConsumption: 0.0,
            ShipLost: true);
    }
}