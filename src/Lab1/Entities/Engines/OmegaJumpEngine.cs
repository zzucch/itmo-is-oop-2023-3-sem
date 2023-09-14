using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class OmegaJumpEngine : IJumpEngine
{
    public OmegaJumpEngine()
    {
        FuelType = Fuel.GravitonicMatter;
        CanEnterSubspace = true;
        SubspaceTravelLength = SubspaceTravel.Omega;
    }

    public Fuel FuelType { get; }
    public bool CanEnterSubspace { get; }
    public SubspaceTravel SubspaceTravelLength { get; }

    public double FuelPerLightYear(int lightYear)
    {
        return double.Log(lightYear);
    }
}