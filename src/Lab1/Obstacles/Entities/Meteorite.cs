using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public class Meteorite : Obstacle
{
    public Meteorite()
    {
        DamageDealt = Damage.Meteorite;
    }
}