using System;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.TravellingStrategies;

public class ImpulseETravellingStrategy : ITravellingStrategy
{
    private const double StartFuelConsumption = 100.0;
    private const double FuelConsumptionPerLightYear = 1000.0;

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType, int acceleration)
    {
        return new TravelResult(
            Success: true,
            TravelTimeTaken: GetTravelTime(distanceLightYear, acceleration),
            FuelConsumed: new Fuel(FuelType.ActivePlasma, StartFuelConsumption + (distanceLightYear * FuelConsumptionPerLightYear)),
            ShipLost: false);
    }

    // t = (2*distance / (a + sqrt(a^2 + 2a*v_0))), v_0 = 0
    // speed(time) = e^t;
    // distance = Integrate([e^time], {0, time}) = e^t - 1;
    // time = ln(distance + 1)
    // x(t) = x0 + v0t + (1/2)at^2
    // x(t) = (1/2)e^t^2
    // speed accelerates exponentially, total acceleration is hard to calculate,
    // but it is never negative, therefore ship would not stop, and
    // therefore acceleration is used as slowing coefficient
    private static TimeSpan GetTravelTime(int distanceLightYear, int acceleration)
    {
        return new TimeSpan((int)double.Log(distanceLightYear + 1) * acceleration);
    }
}