using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public interface IDeflector
{
    DeflectorStrength Strength { get; }
    bool TryDeflect(IObstacle obstacle);
}