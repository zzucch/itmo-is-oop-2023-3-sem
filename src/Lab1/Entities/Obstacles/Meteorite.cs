using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Meteorite : IObstacle
{
    public Meteorite()
    {
        DamageDealt = Damage.Meteorite;
    }

    public Damage DamageDealt { get; }
}