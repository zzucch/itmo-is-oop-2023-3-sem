using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

public class AntimatterFlash : Obstacle
{
    private const int AntimatterFlashPhysicalDamage = 0;

    public AntimatterFlash()
        : base(AntimatterFlashPhysicalDamage)
    {
    }

    protected override void DoDamage(ISpaceShip ship)
    {
        ship.TakePhotonDamage();
    }
}