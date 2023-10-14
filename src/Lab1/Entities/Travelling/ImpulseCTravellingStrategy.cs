using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;

public class ImpulseCTravellingStrategy : ITravellingStrategy
{
    private const double SpeedLightYearsPerHour = 100.0;
    private const double StartFuelConsumption = 100.0;
    private const double FuelConsumptionPerLightYear = 10.0;

    private const EnvironmentType PassableEnvironment = EnvironmentType.NormalSpace;

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType)
    {
        if (environmentType is not PassableEnvironment)
        {
            return new TravelResult(
                Success: false,
                TravelTimeTaken: 0.0,
                FuelTypeConsumed: Fuel.ActivePlasma,
                TravelFuelConsumption: 0.0,
                ShipLost: false);
        }

        return new TravelResult(
            Success: true,
            TravelTimeTaken: distanceLightYear / SpeedLightYearsPerHour,
            FuelTypeConsumed: Fuel.ActivePlasma,
            TravelFuelConsumption: StartFuelConsumption + (distanceLightYear * FuelConsumptionPerLightYear),
            ShipLost: false);
    }
}