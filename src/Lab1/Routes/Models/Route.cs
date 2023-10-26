using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

public record Route
{
    public Route(IReadOnlyCollection<IRouteSegment> routeSegments)
    {
        if (routeSegments.Count == 0)
        {
            throw new ArgumentException("route segments count must be positive");
        }

        RouteSegments = routeSegments;
    }

    public IReadOnlyCollection<IRouteSegment> RouteSegments { get; }
}