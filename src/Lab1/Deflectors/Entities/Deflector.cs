namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public abstract class Deflector : IDeflector
{
    protected Deflector()
    {
    }

    protected Deflector(int hitPoints)
    {
        HitPoints = hitPoints;
    }

    private int HitPoints { get; set; }

    public virtual bool TryPhysicalDeflect(int damage)
    {
        if (HitPoints > damage)
        {
            HitPoints -= damage;
        }

        return HitPoints > damage;
    }

    public virtual bool TryPhotonDeflect()
    {
        return false;
    }
}