using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Asteroid : IObstacle
{
    public Asteroid()
    {
        DamageDealt = Damage.Asteroid;
    }

    public Damage DamageDealt { get; }
}