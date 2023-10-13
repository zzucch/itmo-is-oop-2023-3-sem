using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.RouteSegmentResults;

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

    public DeflectionResult TryDeflect(Damage damage)
    {
        (bool success, int hitPointsLeft) = DeflectionStrategy.TryDeflect(damage, HitPointsLeft);
        bool damageTaken = (HitPointsLeft - hitPointsLeft) > 0;

        return new DeflectionResult(success, damageTaken);
    }
}