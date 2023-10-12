using Itmo.ObjectOrientedProgramming.Lab1.Deflection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class PhysicalDeflectionStrategy : IDeflectionStrategy
{
    public bool TryDeflect(int damage)
    {
        if (HitPoints > damage)
        {
            HitPoints -= damage;
        }

        return HitPoints > damage;
    }
}