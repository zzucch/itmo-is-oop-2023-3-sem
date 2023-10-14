using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class NitriteNebulaRouteSegment : IRouteSegment
{
    public NitriteNebulaRouteSegment(int distanceLightYear, IEnumerable<INitriteNebulaObstacle> obstacles)
    {
        DistanceLightYear = distanceLightYear;
        Obstacles = obstacles;
    }

    public IEnumerable<IObstacle> Obstacles { get; }
    public EnvironmentType EnvironmentType => EnvironmentType.NitriteNebula;
    public int DistanceLightYear { get; }
}