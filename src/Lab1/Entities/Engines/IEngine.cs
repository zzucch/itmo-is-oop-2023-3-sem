using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public interface IEngine
{
    Fuel FuelType { get; }
    bool CanEnterSubspace { get; }
    double FuelPerLightYear(int lightYear);
}