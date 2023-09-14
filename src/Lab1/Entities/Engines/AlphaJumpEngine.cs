using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class AlphaJumpEngine : IJumpEngine
{
    public AlphaJumpEngine()
    {
        FuelType = Fuel.GravitonicMatter;
        CanEnterSubspace = false;
        SubspaceTravelLength = 100;
    }

    public Fuel FuelType { get; }

    public bool CanEnterSubspace { get; }

    public int SubspaceTravelLength { get; }

    public double FuelPerLightYear(int lightYear)
    {
        return 10 * lightYear;
    }
}