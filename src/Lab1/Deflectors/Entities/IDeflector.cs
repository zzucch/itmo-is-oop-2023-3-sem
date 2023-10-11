using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public interface IDeflector
{
    bool TryNormalDeflect(IObstacle obstacle);
    bool TryPhotonDeflect(IObstacle obstacle);
}