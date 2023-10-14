using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;

public interface IRouteSegment
{
    public IEnumerable<IObstacle> Obstacles { get; }
    public EnvironmentType EnvironmentType { get; }
    public int DistanceLightYear { get; }
}