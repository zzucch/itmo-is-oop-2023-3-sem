using System;
using Itmo.ObjectOrientedProgramming.Lab1.FuelMarket.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities;

public class ImpulseCTravellingStrategy : ITravellingStrategy
{
    private const int SpeedLightYearsPerHour = 100;
    private const double StartFuelConsumption = 100.0;
    private const double FuelConsumptionPerLightYear = 10.0;

    private const EnvironmentType PassableEnvironment = EnvironmentType.NormalSpace;

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType)
    {
        if (environmentType is not PassableEnvironment)
        {
            return new TravelResult(
                Success: false,
                TravelTimeTaken: TimeSpan.Zero,
                FuelConsumed: new Fuel(FuelType.None, Amount: 0.0),
                ShipLost: false);
        }

        return new TravelResult(
            Success: true,
            TravelTimeTaken: new TimeSpan(distanceLightYear / SpeedLightYearsPerHour),
            FuelConsumed: new Fuel(FuelType.ActivePlasma, StartFuelConsumption + (distanceLightYear * FuelConsumptionPerLightYear)),
            ShipLost: false);
    }
}