using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineC : IEngine
{
    public ImpulseEngineC()
    {
        FuelType = Fuel.ActivePlasma;
        CanEnterSubspace = false;
    }

    public Fuel FuelType { get; }

    public bool CanEnterSubspace { get; }

    public double FuelPerLightYear(int lightYear)
    {
        return 10;
    }
}