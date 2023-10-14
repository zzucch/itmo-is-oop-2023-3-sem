using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;

public class RouteSegment
{
    public RouteSegment(int distanceLightYear, ICollection<IObstacle> obstacles, EnvironmentType environmentType, double environmentAcceleration)
    {
        DistanceLightYear = distanceLightYear;
        Obstacles = obstacles;
        EnvironmentType = environmentType;
        EnvironmentAcceleration = environmentAcceleration;
    }

    public ICollection<IObstacle> Obstacles { get; init; }
    public double EnvironmentAcceleration { get; }
    public EnvironmentType EnvironmentType { get; }
    public int DistanceLightYear { get; }
}