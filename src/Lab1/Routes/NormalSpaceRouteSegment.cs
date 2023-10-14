using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class NormalSpaceRouteSegment : IRouteSegment
{
    public NormalSpaceRouteSegment(int distanceLightYear, IEnumerable<INormalSpaceObstacle> obstacles)
    {
        DistanceLightYear = distanceLightYear;
        Obstacles = obstacles;
    }

    public IEnumerable<IObstacle> Obstacles { get; }
    public EnvironmentType EnvironmentType => EnvironmentType.NormalSpace;
    public int DistanceLightYear { get; }
}