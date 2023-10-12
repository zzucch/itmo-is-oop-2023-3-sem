namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Meteorite : Obstacle
{
    private const int MeteoritePhysicalDamage = 4;

    public Meteorite()
        : base(MeteoritePhysicalDamage)
    {
    }
}