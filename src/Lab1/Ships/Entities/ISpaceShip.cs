using Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public interface ISpaceShip
{
    RouteSegmentResult Travel(RouteSegment routeSegment);
    void TakePhysicalDamage(int damage);
    void TakePhotonDamage();
}