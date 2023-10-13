using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;

public class ImpulseETravellingStrategy : ITravellingStrategy
{
    private const EnvironmentType PassableEnvironment = EnvironmentType.NormalSpace;
    private const double StartFuelConsumption = 100.0;
    private const double FuelConsumptionPerLightYear = 100.0;

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType)
    {
        if (environmentType is not PassableEnvironment)
        {
            return new TravelResult(
                Success: false,
                TravelTimeTaken: 0.0,
                FuelTypeConsumed: Fuel.ActivePlasma,
                TravelFuelConsumption: 0.0);
        }

        return new TravelResult(
            Success: true,
            TravelTimeTaken: double.Log(distanceLightYear + 1),
            FuelTypeConsumed: Fuel.ActivePlasma,
            TravelFuelConsumption: StartFuelConsumption + (distanceLightYear * FuelConsumptionPerLightYear));
    }
}