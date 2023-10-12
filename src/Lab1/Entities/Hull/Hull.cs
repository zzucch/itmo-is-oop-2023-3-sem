using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

public class Hull
{
    public Hull(IDeflectionStrategy deflectionStrategy, MassDimensional massDimensional)
    {
        DeflectionStrategy = deflectionStrategy;
        MassDimensional = massDimensional;
    }

    private IDeflectionStrategy DeflectionStrategy { get; set; }
    private MassDimensional MassDimensional { get; }
    private int HitPointsLeft { get; set; } = 500;

    public bool TryHullDeflect(Damage damage)
    {
        (bool success, HitPointsLeft) = DeflectionStrategy.TryDeflect(damage, HitPointsLeft);

        return success;
    }
}