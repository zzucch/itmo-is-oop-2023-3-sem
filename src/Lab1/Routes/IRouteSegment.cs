using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public interface IRouteSegment
{
    public IEnumerable<IObstacle> Obstacles { get; }
    public EnvironmentType EnvironmentType { get; }
    public int DistanceLightYear { get; }
}