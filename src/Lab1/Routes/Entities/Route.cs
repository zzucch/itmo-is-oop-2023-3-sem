using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;

public class Route
{
    public Route(IReadOnlyCollection<IRouteSegment> routeSegments)
    {
        RouteSegments = routeSegments;
    }

    public IReadOnlyCollection<IRouteSegment> RouteSegments { get; }
}