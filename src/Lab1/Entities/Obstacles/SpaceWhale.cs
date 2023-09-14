using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class SpaceWhale : IObstacle
{
    public SpaceWhale()
    {
        DamageDealt = Damage.SpaceWhale;
    }

    public Damage DamageDealt { get; }
}