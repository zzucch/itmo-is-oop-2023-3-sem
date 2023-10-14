using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;

public class RouteSegment
{
    public RouteSegment(int distanceLightYear, ICollection<IObstacle> obstacles, EnvironmentType environmentType)
    {
        DistanceLightYear = distanceLightYear;
        Obstacles = obstacles;
        EnvironmentType = environmentType;
    }

    public ICollection<IObstacle> Obstacles { get; }
    public EnvironmentType EnvironmentType { get; }
    public int DistanceLightYear { get; }
}