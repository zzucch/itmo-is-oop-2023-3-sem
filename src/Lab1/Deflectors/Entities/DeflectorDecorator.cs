using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public abstract class DeflectorDecorator : Deflector
{
    protected DeflectorDecorator(Deflector deflector)
    {
        Deflector = deflector;
    }

    private Deflector Deflector { get; }

    public override bool TryNormalDeflect(IObstacle obstacle)
    {
        return Deflector.TryNormalDeflect(obstacle);
    }

    public override bool TryPhotonDeflect(IObstacle obstacle)
    {
        return Deflector.TryPhotonDeflect(obstacle);
    }
}