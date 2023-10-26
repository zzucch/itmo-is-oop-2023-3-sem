using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;

public interface IRouteSegment
{
    public IEnumerable<IObstacle> Obstacles { get; }
    public EnvironmentType EnvironmentType { get; }
    public int DistanceLightYear { get; }
    public int Acceleration { get; }
    public RouteSegmentResult BeTravelled(ISpaceShip ship);
}