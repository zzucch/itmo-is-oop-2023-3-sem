using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;

public class DenseNebulaRouteSegment : IRouteSegment
{
    public DenseNebulaRouteSegment(int distanceLightYear, IEnumerable<IDenseNebulaObstacle> obstacles, int acceleration = 0)
    {
        DistanceLightYear = distanceLightYear;
        Obstacles = obstacles;
        Acceleration = acceleration;
    }

    public IEnumerable<IObstacle> Obstacles { get; }
    public EnvironmentType EnvironmentType => EnvironmentType.DenseNebula;
    public int DistanceLightYear { get; }
    public int Acceleration { get; }
}