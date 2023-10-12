using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class ShipService
{
    public static IReadOnlyCollection<RouteSegmentResult> LaunchShip(ISpaceShip ship, Route route)
    {
        var results = new List<RouteSegmentResult>();
        foreach (RouteSegment segment in route.RouteSegments)
        {
            if (results.All(i => i.Success))
            {
                results.Add(ship.Travel(segment));
            }
        }

        return results;
    }
}