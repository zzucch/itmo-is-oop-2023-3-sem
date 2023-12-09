using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class ShipLauncher
{
    private readonly Route _route;

    public ShipLauncher(Route route)
    {
        _route = route;
    }

    public IEnumerable<RouteSegmentResult> LaunchShip(ISpaceShip ship)
    {
        return _route.RouteSegments.Select(segment => segment.BeTravelled(ship)).ToList();
    }
}