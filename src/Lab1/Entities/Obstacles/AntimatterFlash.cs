using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class AntimatterFlash : IObstacle
{
    private const int AntimatterPhotonDamage = 1;

    public void DoDamage(ISpaceShip ship)
    {
        ship.TakeDamage(new Damage(DamageType.Photon, AntimatterPhotonDamage));
    }
}