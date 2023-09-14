using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public interface IDeflector
{
    DeflectorStrength Strength { get; }
    bool IsFunctioning { get; }
    bool Deflect(Obstacle obstacle);
}