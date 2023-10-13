using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteSegmentResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;

public class ImpulseCTravellingStrategy : ITravellingStrategy
{
    private const double SpeedLightYearsPerHour = 10.0;
    private const double StartFuelConsumption = 100.0;
    private const double FuelConsumptionPerLightYear = 10.0;

    private readonly EnvironmentType[] _passableEnvironments =
    {
        EnvironmentType.NormalSpace,
        EnvironmentType.DenseNebula,
    };

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType, double environmentAcceleration)
    {
        if (_passableEnvironments.Contains(environmentType) is false)
        {
            return new TravelResult(
                Success: false,
                TravelTimeTaken: 0.0,
                FuelTypeConsumed: Fuel.ActivePlasma,
                TravelFuelConsumption: 0.0,
                ShipLost: false);
        }

        // TODO
        if (environmentAcceleration < 0)
        {
            double stopDistance = GetStopDistance(environmentAcceleration);
            if (stopDistance < distanceLightYear)
            {
                return new TravelResult(
                    Success: true,
                    TravelTimeTaken: stopDistance / SpeedLightYearsPerHour,
                    FuelTypeConsumed: Fuel.ActivePlasma,
                    TravelFuelConsumption: StartFuelConsumption + (stopDistance * FuelConsumptionPerLightYear),
                    ShipLost: true);
            }
        }

        return new TravelResult(
            Success: true,
            TravelTimeTaken: distanceLightYear / SpeedLightYearsPerHour,
            FuelTypeConsumed: Fuel.ActivePlasma,
            TravelFuelConsumption: StartFuelConsumption + (distanceLightYear * FuelConsumptionPerLightYear),
            ShipLost: false);
    }

    // stop_distance = (start_speed^2 - end_speed^2) / (2 * acceleration), end_speed = 0 when ship stops
    private static double GetStopDistance(double environmentAcceleration)
    {
        return (SpeedLightYearsPerHour * SpeedLightYearsPerHour) / (2 * environmentAcceleration);
    }
}