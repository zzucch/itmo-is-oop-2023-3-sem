using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public interface IObstacle
{
    ShipDeflectionResult Damage(ISpaceShip ship);
}