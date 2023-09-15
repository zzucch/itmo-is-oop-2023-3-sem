using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Meteorite : Obstacle
{
    public Meteorite()
    {
        DamageDealt = Damage.Meteorite;
    }
}