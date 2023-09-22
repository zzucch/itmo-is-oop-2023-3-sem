using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public class Asteroid : IObstacle
{
    public int DamageDealt { get; init; } = Damage.Asteroid;
}