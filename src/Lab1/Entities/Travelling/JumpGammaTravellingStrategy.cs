using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteSegmentResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;

public class JumpGammaTravellingStrategy : ITravellingStrategy
{
    private const double SpeedLightYearsPerHour = 100.0;
    private const int MaxTravelDistance = 10000;

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
                TravelFuelConsumption: MaxTravelDistance * MaxTravelDistance,
                ShipLost: true);
        }

        return new TravelResult(
            Success: true,
            TravelTimeTaken: distanceLightYear / SpeedLightYearsPerHour,
            FuelTypeConsumed: Fuel.GravitonMatter,
            TravelFuelConsumption: distanceLightYear * distanceLightYear,
            ShipLost: false);
    }
}