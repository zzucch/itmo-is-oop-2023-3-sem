using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;

public interface IRouteSegment
{
    public IEnumerable<IObstacle> Obstacles { get; }
    public EnvironmentType EnvironmentType { get; }
    public int DistanceLightYear { get; }
}