using System;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.TravellingStrategies;

public class JumpGammaTravellingStrategy : IDenseNebulaExclusiveTravellingStrategy
{
    private const int SpeedLightYearsPerHour = 100;
    private const int MaxTravelDistance = 10000;

    private const EnvironmentType PassableEnvironment = EnvironmentType.DenseNebula;

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType, int acceleration)
    {
        if (environmentType is not PassableEnvironment)
        {
            return new TravelResult(
                Success: false,
                TravelTimeTaken: TimeSpan.Zero,
                FuelConsumed: new Fuel(FuelType.None, 0.0),
                ShipLost: false);
        }

        if (distanceLightYear > MaxTravelDistance)
        {
            return new TravelResult(
                Success: false,
                TravelTimeTaken: new TimeSpan(MaxTravelDistance / SpeedLightYearsPerHour),
                FuelConsumed: new Fuel(FuelType.GravitonMatter, MaxTravelDistance * MaxTravelDistance),
                ShipLost: true);
        }

        return new TravelResult(
            Success: true,
            TravelTimeTaken: new TimeSpan(distanceLightYear / SpeedLightYearsPerHour),
            FuelConsumed: new Fuel(FuelType.GravitonMatter, distanceLightYear * distanceLightYear),
            ShipLost: false);
    }
}