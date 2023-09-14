using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public interface IJumpEngine : IEngine
{
    SubspaceTravel SubspaceTravelLength { get; }
}