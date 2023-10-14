using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class DenseNebulaRouteSegment : IRouteSegment
{
    public DenseNebulaRouteSegment(int distanceLightYear, IEnumerable<IDenseNebulaObstacle> obstacles)
    {
        DistanceLightYear = distanceLightYear;
        Obstacles = obstacles;
    }

    public IEnumerable<IObstacle> Obstacles { get; }
    public EnvironmentType EnvironmentType => EnvironmentType.DenseNebula;
    public int DistanceLightYear { get; }
}