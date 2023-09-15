using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class JumpEngine
{
    public Fuel FuelType { get; init; } = Fuel.GravitonicMatter;
    public SubspaceTravel SubspaceTravelLength { get; init; }
}