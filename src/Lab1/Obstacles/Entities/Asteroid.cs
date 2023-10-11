namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public class Asteroid : Obstacle
{
    private const int AsteroidPhysicalDamage = 1;

    public Asteroid()
        : base(AsteroidPhysicalDamage)
    {
    }
}