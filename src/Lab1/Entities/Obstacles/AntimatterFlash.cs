using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

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