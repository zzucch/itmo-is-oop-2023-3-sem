using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Ships;

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
        foreach (IRouteSegment segment in Route.RouteSegments)
        {
            var deflectionResults = segment.Obstacles.Select(obstacle => obstacle.Damage(ship)).ToList();

            ShipTravelResult travelResult = ship.Travel(segment);

            results.Add(ConvertToRouteSegmentResult(travelResult, deflectionResults));
        }

        return results;
    }

    private static RouteSegmentResult ConvertToRouteSegmentResult(ShipTravelResult travelResult, IReadOnlyCollection<ShipDeflectionResult> deflectionResults)
    {
        return new RouteSegmentResult(
            Success: travelResult.TravelResult.Success &&
                     (deflectionResults.All(i => i.DeflectorResult is null || i.DeflectorResult.Success) ||
                      deflectionResults.All(i => i.HullResult is null || i.HullResult.Success)),
            travelResult.TravelResult.FuelTypeConsumed,
            travelResult.TravelResult.TravelFuelConsumption,
            travelResult.TravelResult.TravelTimeTaken,
            travelResult.TravelResult.ShipLost,
            CrewLost: travelResult.CrewState is CrewState.Dead,
            ShipDestroyed: deflectionResults.Any(i => i.HullResult?.DeflectingEntityDestroyed is true),
            DeflectorDestroyed: deflectionResults.Any(i => i.DeflectorResult?.DeflectingEntityDestroyed is true));
    }
}