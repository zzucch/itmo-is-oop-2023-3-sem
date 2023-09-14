using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class GammaJumpEngine : IJumpEngine
{
    public GammaJumpEngine()
    {
        FuelType = Fuel.GravitonicMatter;
        CanEnterSubspace = true;
        SubspaceTravelLength = SubspaceTravel.Gamma;
    }

    public Fuel FuelType { get; }
    public bool CanEnterSubspace { get; }
    public SubspaceTravel SubspaceTravelLength { get; }

    public double FuelPerLightYear(int lightYear)
    {
        return lightYear * lightYear;
    }
}