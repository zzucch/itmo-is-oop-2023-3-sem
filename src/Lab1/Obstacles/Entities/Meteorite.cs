namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public class Meteorite : Obstacle
{
    private const int MeteoritePhysicalDamage = 4;

    public Meteorite()
        : base(MeteoritePhysicalDamage)
    {
    }
}