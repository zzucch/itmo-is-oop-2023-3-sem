using System;
using Itmo.ObjectOrientedProgramming.Lab1.FuelMarket.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

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
            TravelTimeTaken: TimeSpan.Zero,
            FuelConsumed: new Fuel(FuelType.None, Amount: 0.0),
            ShipLost: true);
    }
}