using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;

public class ImpulseCTravellingStrategy : ITravellingStrategy
{
    private readonly EnvironmentType[] _passableEnvironments = new[]
    {
        EnvironmentType.NormalSpace,
        EnvironmentType.DenseNebula,
    };

    private const double SpeedLightYearsPerHour = 10.0;
    private const double StartFuelConsumption = 100.0;
    private const double FuelConsumptionPerLightYear = 10.0;

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType)
    {
        if (!_passableEnvironments.Contains(environmentType))
        {
            return new TravelResult(
                Success: false,
                TravelTimeTaken: 0.0,
                FuelTypeConsumed: Fuel.ActivePlasma,
                TravelFuelConsumption: 0.0);
        }

        return new TravelResult(
            Success: true,
            TravelTimeTaken: distanceLightYear / SpeedLightYearsPerHour,
            FuelTypeConsumed: Fuel.ActivePlasma,
            TravelFuelConsumption: StartFuelConsumption + (distanceLightYear * FuelConsumptionPerLightYear));
    }
}