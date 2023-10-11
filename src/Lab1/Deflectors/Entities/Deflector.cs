namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public abstract class Deflector : IDeflector
{
    private int Hp { get; set; }

    public virtual bool TryPhysicalDeflect(int damage)
    {
        if (Hp > damage)
        {
            Hp -= damage;
        }

        return Hp > damage;
    }

    public virtual bool TryPhotonDeflect()
    {
        return false;
    }
}