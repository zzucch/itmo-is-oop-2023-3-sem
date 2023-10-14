using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;

public class ImpulseETravellingStrategy : INegativeAccelerationTolerantStrategy
{
    private const double StartFuelConsumption = 100.0;
    private const double FuelConsumptionPerLightYear = 1000.0;

    private readonly EnvironmentType[] _passableEnvironments =
    {
        EnvironmentType.NormalSpace,
        EnvironmentType.NitriteNebula,
    };

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType)
    {
        if (_passableEnvironments.Contains(environmentType) is false)
        {
            return new TravelResult(
                Success: false,
                TravelTimeTaken: TimeSpan.Zero,
                FuelTypeConsumed: Fuel.ActivePlasma,
                TravelFuelConsumption: 0.0,
                ShipLost: false);
        }

        // TravelTimeTaken:
        // speed(time) = e^t;
        // distance = Integrate([e^time], {0, time}) = e^t - 1;
        // time = ln(distance + 1)
        return new TravelResult(
            Success: true,
            TravelTimeTaken: new TimeSpan((int)double.Log(distanceLightYear + 1)),
            FuelTypeConsumed: Fuel.ActivePlasma,
            TravelFuelConsumption: StartFuelConsumption + (distanceLightYear * FuelConsumptionPerLightYear),
            ShipLost: false);
    }
}