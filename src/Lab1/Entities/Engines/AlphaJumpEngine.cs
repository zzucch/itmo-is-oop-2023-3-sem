using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class AlphaJumpEngine : IJumpEngine
{
    public AlphaJumpEngine()
    {
        FuelType = Fuel.GravitonicMatter;
        CanEnterSubspace = false;
        SubspaceTravelLength = SubspaceTravel.Alpha;
    }

    public Fuel FuelType { get; }

    public bool CanEnterSubspace { get; }

    public SubspaceTravel SubspaceTravelLength { get; }

    public double FuelPerLightYear(int lightYear)
    {
        return 10 * lightYear;
    }
}