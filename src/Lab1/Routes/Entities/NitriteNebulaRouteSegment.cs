using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;

public class NitriteNebulaRouteSegment : IRouteSegment
{
    public NitriteNebulaRouteSegment(int distanceLightYear, IEnumerable<INitriteNebulaObstacle> obstacles, int acceleration = 0)
    {
        DistanceLightYear = distanceLightYear;
        Obstacles = obstacles;
        Acceleration = acceleration;
    }

    public IEnumerable<IObstacle> Obstacles { get; }
    public EnvironmentType EnvironmentType => EnvironmentType.NitriteNebula;
    public int DistanceLightYear { get; }
    public int Acceleration { get; }
}