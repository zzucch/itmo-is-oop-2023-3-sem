namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class DeflectorDecorator : Deflector
{
    protected DeflectorDecorator(Deflector deflector)
    {
        Deflector = deflector;
    }

    private Deflector Deflector { get; }

    public override bool TryPhysicalDeflect(int damage)
    {
        return Deflector.TryPhysicalDeflect(damage);
    }

    public override bool TryPhotonDeflect()
    {
        return Deflector.TryPhotonDeflect();
    }
}