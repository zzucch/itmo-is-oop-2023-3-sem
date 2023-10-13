using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

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
        if (environmentAcceleration < 0 && IsStoppedDuringTravel(distanceLightYear, environmentAcceleration))
        {
            return new TravelResult(
                Success: true,
                TravelTimeTaken: distanceLightYear / SpeedLightYearsPerHour,
                FuelTypeConsumed: Fuel.ActivePlasma,
                TravelFuelConsumption: StartFuelConsumption + ( * FuelConsumptionPerLightYear),
                ShipLost: true);
        }

        return new TravelResult(
            Success: true,
            TravelTimeTaken: distanceLightYear / SpeedLightYearsPerHour,
            FuelTypeConsumed: Fuel.ActivePlasma,
            TravelFuelConsumption: StartFuelConsumption + (distanceLightYear * FuelConsumptionPerLightYear),
            ShipLost: false);
    }

    // stop_distance = (start_speed^2 - end_speed^2) / (2 * acceleration), end_speed = 0 when ship stops
    // if travel_distance > stop_distance, ship is stopped
    private static bool IsStoppedDuringTravel(int distanceLightYear, double environmentAcceleration)
    {
        return distanceLightYear > (SpeedLightYearsPerHour * SpeedLightYearsPerHour) / (2 * environmentAcceleration);
    }
}