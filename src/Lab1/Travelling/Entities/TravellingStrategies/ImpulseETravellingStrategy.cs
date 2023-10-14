using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.TravellingStrategies;

public class ImpulseETravellingStrategy : ITravellingStrategy
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
                FuelConsumed: new Fuel(FuelType.None, 0.0),
                ShipLost: false);
        }

        // TravelTimeTaken:
        // speed(time) = e^t;
        // distance = Integrate([e^time], {0, time}) = e^t - 1;
        // time = ln(distance + 1)
        return new TravelResult(
            Success: true,
            TravelTimeTaken: new TimeSpan((int)double.Log(distanceLightYear + 1)),
            FuelConsumed: new Fuel(FuelType.ActivePlasma, StartFuelConsumption + (distanceLightYear * FuelConsumptionPerLightYear)),
            ShipLost: false);
    }
}