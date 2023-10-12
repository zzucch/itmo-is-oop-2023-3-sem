using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

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