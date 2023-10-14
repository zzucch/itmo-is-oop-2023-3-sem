using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Hull;

public class Hull
{
    public Hull(IDeflectionStrategy deflectionStrategy, MassDimensional massDimensional)
    {
        DeflectionStrategy = deflectionStrategy;
        MassDimensional = massDimensional;
    }

    private IDeflectionStrategy DeflectionStrategy { get; }
    private MassDimensional MassDimensional { get; }
    private int HitPointsLeft { get; set; } = 500;

    public DeflectionResult TryDeflect(Damage.Models.Damage damage)
    {
        (bool success, int hitPointsLeft) = DeflectionStrategy.TryDeflect(damage, HitPointsLeft);
        bool damageTaken = (HitPointsLeft - hitPointsLeft) > 0;
        HitPointsLeft = hitPointsLeft;

        return new DeflectionResult(success, damageTaken);
    }
}