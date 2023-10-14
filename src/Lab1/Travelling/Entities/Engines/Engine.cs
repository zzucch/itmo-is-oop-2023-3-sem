using System;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.Engines;

public class Engine
{
    public Engine(ITravellingStrategy travellingStrategy)
    {
        TravellingStrategy = travellingStrategy;
    }

    private ITravellingStrategy TravellingStrategy { get; }

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType)
    {
        if (environmentType is EnvironmentType.DenseNebula && TravellingStrategy is IDenseNebulaExclusiveTravellingStrategy)
        {
            return TravellingStrategy.TryTravel(distanceLightYear, environmentType);
        }

        if (environmentType is not EnvironmentType.DenseNebula && TravellingStrategy is not IDenseNebulaExclusiveTravellingStrategy)
        {
            return TravellingStrategy.TryTravel(distanceLightYear, environmentType);
        }

        return new TravelResult(
            Success: false,
            TravelTimeTaken: TimeSpan.Zero,
            FuelConsumed: new Fuel(FuelType.None, Amount: 0.0),
            ShipLost: true);
    }
}