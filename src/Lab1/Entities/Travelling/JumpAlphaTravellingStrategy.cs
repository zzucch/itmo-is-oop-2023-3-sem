using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteSegmentResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;

public class JumpAlphaTravellingStrategy : ITravellingStrategy
{
    private const double SpeedLightYearsPerHour = 100.0;
    private const double FuelConsumptionPerLightYear = 10.0;
    private const int MaxTravelDistance = 1000;

    private const EnvironmentType PassableEnvironment = EnvironmentType.NitriteNebula;

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType, double environmentAcceleration)
    {
        if (environmentType is not PassableEnvironment)
        {
            return new TravelResult(
                Success: false,
                TravelTimeTaken: 0.0,
                FuelTypeConsumed: Fuel.GravitonMatter,
                TravelFuelConsumption: 0.0,
                ShipLost: false);
        }

        if (distanceLightYear > MaxTravelDistance)
        {
            return new TravelResult(
                Success: false,
                TravelTimeTaken: MaxTravelDistance / SpeedLightYearsPerHour,
                FuelTypeConsumed: Fuel.GravitonMatter,
                TravelFuelConsumption: MaxTravelDistance * FuelConsumptionPerLightYear,
                ShipLost: true);
        }

        return new TravelResult(
            Success: true,
            TravelTimeTaken: distanceLightYear / SpeedLightYearsPerHour,
            FuelTypeConsumed: Fuel.GravitonMatter,
            TravelFuelConsumption: distanceLightYear * FuelConsumptionPerLightYear,
            ShipLost: false);
    }
}