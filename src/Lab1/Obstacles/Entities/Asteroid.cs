using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public class Asteroid : Obstacle
{
    public Asteroid()
    {
        DamageDealt = Damage.Asteroid;
    }
}