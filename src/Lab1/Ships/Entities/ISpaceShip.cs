using Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface ISpaceShip
{
    RouteSegmentResult Travel(RouteSegment routeSegment);
}