namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public class SpaceWhales : Obstacle
{
    private const int SpaceWhalePhysicalDamage = 40;

    public SpaceWhales(int amount)
        : base(physicalDamage: SpaceWhalePhysicalDamage * amount)
    {
    }
}