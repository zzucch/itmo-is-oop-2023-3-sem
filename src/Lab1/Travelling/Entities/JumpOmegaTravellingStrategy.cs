using System;
using Itmo.ObjectOrientedProgramming.Lab1.FuelMarket.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities;

public class JumpOmegaTravellingStrategy : ITravellingStrategy
{
    private const int SpeedLightYearsPerHour = 100;
    private const int MaxTravelDistance = 5000;

    private const EnvironmentType PassableEnvironment = EnvironmentType.DenseNebula;

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType)
    {
        if (environmentType is not PassableEnvironment)
        {
            return new TravelResult(
                Success: false,
                TravelTimeTaken: TimeSpan.Zero,
                FuelTypeConsumed: Fuel.GravitonMatter,
                TravelFuelConsumption: 0.0,
                ShipLost: false);
        }

        if (distanceLightYear > MaxTravelDistance)
        {
            return new TravelResult(
                Success: false,
                TravelTimeTaken: new TimeSpan(MaxTravelDistance / SpeedLightYearsPerHour),
                FuelTypeConsumed: Fuel.GravitonMatter,
                TravelFuelConsumption: MaxTravelDistance * double.Log(MaxTravelDistance),
                ShipLost: true);
        }

        return new TravelResult(
            Success: true,
            TravelTimeTaken: new TimeSpan(distanceLightYear / SpeedLightYearsPerHour),
            FuelTypeConsumed: Fuel.GravitonMatter,
            TravelFuelConsumption: distanceLightYear * double.Log(distanceLightYear),
            ShipLost: false);
    }
}