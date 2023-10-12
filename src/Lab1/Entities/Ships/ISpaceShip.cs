using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public interface ISpaceShip
{
    RouteSegmentResult Travel(RouteSegment routeSegment);
    void TakePhysicalDamage(int damage);
    void TakePhotonDamage();
}