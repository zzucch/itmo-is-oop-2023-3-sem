using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface ISpaceShip
{
    ShipTravelResult Travel(IRouteSegment routeSegment);
    ShipDeflectionResult TakeDamage(Damage damage);
}