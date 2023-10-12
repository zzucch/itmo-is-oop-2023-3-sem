namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class SpaceWhales : Obstacle
{
    private const int SpaceWhalePhysicalDamage = 1000;

    public SpaceWhales(int amount)
        : base(physicalDamage: SpaceWhalePhysicalDamage * amount)
    {
    }
}