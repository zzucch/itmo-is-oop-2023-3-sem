namespace Itmo.ObjectOrientedProgramming.Lab1.Deflection;

public interface IDeflectionStrategy
{
    bool Deflect(Damage damage, int hitPoints);
}