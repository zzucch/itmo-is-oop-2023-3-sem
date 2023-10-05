using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public class ImpulseEngineE : IEngine
{
    public ImpulseEngineE()
    {
        FuelType = Fuel.ActivePlasma;
        CanEnterSubspace = false;
    }

    public Fuel FuelType { get; }

    public bool CanEnterSubspace { get; }

    public double TravelFuelConsumption(int lightYear)
    {
        return double.Exp(lightYear);
    }
}