using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;

public class RouteSegment
{
    public RouteSegment(int length, ICollection<IObstacle> obstacles, Environment environment)
    {
        Length = length;
        Obstacles = obstacles;
        Environment = environment;
    }

    public int Length { get; init; }
    public ICollection<IObstacle> Obstacles { get; init; }
    public Environment Environment { get; protected init; }
}