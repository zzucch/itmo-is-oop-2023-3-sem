using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

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

    public override bool TryPhotonDeflect(IObstacle obstacle)
    {
        return Deflector.TryPhotonDeflect(obstacle);
    }
}