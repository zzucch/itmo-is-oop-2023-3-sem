using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Obstacles;

public interface IObstacle
{
    ShipDeflectionResult Damage(ISpaceShip ship);
}