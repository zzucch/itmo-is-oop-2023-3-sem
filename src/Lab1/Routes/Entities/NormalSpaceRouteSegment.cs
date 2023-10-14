using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;

public class NormalSpaceRouteSegment : IRouteSegment
{
    public NormalSpaceRouteSegment(int distanceLightYear, IEnumerable<INormalSpaceObstacle> obstacles)
    {
        DistanceLightYear = distanceLightYear;
        Obstacles = obstacles;
        Acceleration = 0;
    }

    public IEnumerable<IObstacle> Obstacles { get; }
    public EnvironmentType EnvironmentType => EnvironmentType.NormalSpace;
    public int DistanceLightYear { get; }
    public int Acceleration { get; }
}