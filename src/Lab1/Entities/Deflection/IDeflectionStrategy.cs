namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;

public interface IDeflectionStrategy
{
    bool Deflect(Damage damage, int hitPoints);
}