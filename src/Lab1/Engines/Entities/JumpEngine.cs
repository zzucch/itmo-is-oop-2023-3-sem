using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public abstract class JumpEngine
{
    public Fuel FuelType { get; init; } = Fuel.GravitonMatter;
    public SubspaceTravel SubspaceTravelDistance { get; init; }
}