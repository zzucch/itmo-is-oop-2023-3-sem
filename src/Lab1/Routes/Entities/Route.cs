using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;

public class Route
{
    public Route(IReadOnlyCollection<RouteSegment> routeSegments)
    {
        RouteSegments = routeSegments;
    }

    public IReadOnlyCollection<RouteSegment> RouteSegments { get; init; }
}