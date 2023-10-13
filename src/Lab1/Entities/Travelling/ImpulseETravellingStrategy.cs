using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;

public class ImpulseETravellingStrategy : ITravellingStrategy
{
    private const double StartFuelConsumption = 100.0;
    private const double FuelConsumptionPerLightYear = 100.0;

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

        // TravelTimeTaken:
        // speed(time) = e^t;
        // distance = Integrate([e^time], {0, time}) = e^t - 1;
        // time = ln(distance + 1)
        return new TravelResult(
            Success: true,
            TravelTimeTaken: double.Log(distanceLightYear + 1),
            FuelTypeConsumed: Fuel.ActivePlasma,
            TravelFuelConsumption: StartFuelConsumption + (distanceLightYear * FuelConsumptionPerLightYear),
            ShipLost: false);
    }
}