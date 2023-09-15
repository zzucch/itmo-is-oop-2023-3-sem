using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public abstract class Obstacle
{
    public Damage DamageDealt { get; protected init; }
}