using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public class Meteorite : IObstacle
{
    public int DamageDealt { get; init; } = Damage.Meteorite;
}