namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public interface IDeflector
{
    bool TryPhysicalDeflect(int damage);
    bool TryPhotonDeflect();
}