using System;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.TravellingStrategies;

public class ImpulseCTravellingStrategy : ITravellingStrategy
{
    private const int SpeedLightYearsPerTicks = 100;
    private const double StartFuelConsumption = 100.0;
    private const double FuelConsumptionPerLightYear = 10.0;

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType, int acceleration)
    {
        if (acceleration >= 0)
        {
            return new TravelResult(
                Success: true,
                TravelTimeTaken: new TimeSpan(distanceLightYear / SpeedLightYearsPerTicks),
                FuelConsumed: new Fuel(FuelType.ActivePlasma, StartFuelConsumption + (distanceLightYear * FuelConsumptionPerLightYear)),
                ShipLost: false);
        }

        int maxTravelDistance = GetMaxTravelDistance(acceleration);
        if (distanceLightYear > maxTravelDistance)
        {
            return new TravelResult(
                Success: false,
                TravelTimeTaken: GetTravelTime(maxTravelDistance, acceleration),
                new Fuel(FuelType.ActivePlasma, StartFuelConsumption + (maxTravelDistance * FuelConsumptionPerLightYear)),
                ShipLost: true);
        }

        return new TravelResult(
            Success: true,
            TravelTimeTaken: new TimeSpan(distanceLightYear / SpeedLightYearsPerTicks),
            FuelConsumed: new Fuel(FuelType.ActivePlasma, StartFuelConsumption + (distanceLightYear * FuelConsumptionPerLightYear)),
            ShipLost: false);
    }

    // stop_distance = (v^2 - v_0^2) / (2a), where v = 0 - ship stopped
    private static int GetMaxTravelDistance(int acceleration)
    {
        return (-SpeedLightYearsPerTicks ^ 2) / (2 * acceleration);
    }

    // t = (2*distance / (a + sqrt(a^2 + 2a*v_0)))
    private static TimeSpan GetTravelTime(int distance, int acceleration)
    {
        return new TimeSpan(2 * distance / (acceleration + (int)double.Sqrt(acceleration ^ 2 + (2 * acceleration * SpeedLightYearsPerTicks))));
    }
}