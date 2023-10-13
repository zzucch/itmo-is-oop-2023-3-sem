using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;

public class RouteSegment
{
    public RouteSegment(int distanceLightYear, ICollection<Obstacle> obstacles, Environment environment)
    {
        DistanceLightYear = distanceLightYear;
        Obstacles = obstacles;
        Environment = environment;
    }

    public Environment Environment { get; protected init; }
    public ICollection<Obstacle> Obstacles { get; init; }
    public int DistanceLightYear { get; init; }
}