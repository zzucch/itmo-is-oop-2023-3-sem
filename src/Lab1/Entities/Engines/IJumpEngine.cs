namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public interface IJumpEngine : IEngine
{
    int SubspaceTravelLength { get; }
}