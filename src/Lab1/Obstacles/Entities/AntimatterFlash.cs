using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public class AntimatterFlash : Obstacle
{
    public AntimatterFlash()
    {
    }

    protected override void DoDamage(ISpaceShip ship)
    {
        ship.TakePhotonDamage();
    }
}