using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class ShipLauncher
{
    public ShipLauncher(Route route)
    {
        Route = route;
    }

    private Route Route { get; }

    public IEnumerable<RouteSegmentResult> LaunchShip(ISpaceShip ship)
    {
        var results = new List<RouteSegmentResult>();
        foreach (RouteSegment segment in Route.RouteSegments)
        {
            var deflectionResults = segment.Obstacles.Select(obstacle => obstacle.Damage(ship)).ToList();

            ShipTravelResult travelResult = ship.Travel(segment);

            results.Add(new RouteSegmentResult(travelResult, deflectionResults));
        }

        return results;
    }
}