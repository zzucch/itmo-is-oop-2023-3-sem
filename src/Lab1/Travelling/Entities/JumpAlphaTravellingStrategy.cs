using System;
using Itmo.ObjectOrientedProgramming.Lab1.FuelMarket.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities;

public class JumpAlphaTravellingStrategy : ITravellingStrategy
{
    private const int SpeedLightYearsPerHour = 100;
    private const double FuelConsumptionPerLightYear = 10.0;
    private const int MaxTravelDistance = 1000;

    private const EnvironmentType PassableEnvironment = EnvironmentType.DenseNebula;

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType)
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
                FuelConsumed: new Fuel(FuelType.GravitonMatter, MaxTravelDistance * FuelConsumptionPerLightYear),
                ShipLost: true);
        }

        return new TravelResult(
            Success: true,
            TravelTimeTaken: new TimeSpan(distanceLightYear / SpeedLightYearsPerHour),
            FuelConsumed: new Fuel(FuelType.GravitonMatter, distanceLightYear * FuelConsumptionPerLightYear),
            ShipLost: false);
    }
}