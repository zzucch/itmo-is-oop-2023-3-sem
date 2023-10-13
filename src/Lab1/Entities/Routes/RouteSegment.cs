using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;

public class RouteSegment
{
    public RouteSegment(int distanceLightYear, ICollection<Obstacle> obstacles, EnvironmentType environmentType)
    {
        DistanceLightYear = distanceLightYear;
        Obstacles = obstacles;
        EnvironmentType = environmentType;
    }

    public EnvironmentType EnvironmentType { get; protected init; }
    public ICollection<Obstacle> Obstacles { get; init; }
    public int DistanceLightYear { get; init; }
}