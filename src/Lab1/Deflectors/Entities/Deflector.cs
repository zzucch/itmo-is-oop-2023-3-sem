using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public abstract class Deflector : IDeflector
{
    public virtual bool TryNormalDeflect(IObstacle obstacle)
    {
        throw new System.NotImplementedException();
    }

    public virtual bool TryPhotonDeflect(IObstacle obstacle)
    {
        return false;
    }
}