using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;

public interface IRoute
{
    Environment Environment { get; protected init; }
    ICollection<IObstacle> Obstacles { get; protected init; }
}