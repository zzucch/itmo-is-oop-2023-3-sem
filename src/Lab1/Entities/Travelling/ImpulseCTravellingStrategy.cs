using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;

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
                FuelTypeConsumed: Fuel.ActivePlasma,
                TravelFuelConsumption: 0.0,
                ShipLost: false);
        }

        return new TravelResult(
            Success: true,
            TravelTimeTaken: new TimeSpan(distanceLightYear / SpeedLightYearsPerHour),
            FuelTypeConsumed: Fuel.ActivePlasma,
            TravelFuelConsumption: StartFuelConsumption + (distanceLightYear * FuelConsumptionPerLightYear),
            ShipLost: false);
    }
}