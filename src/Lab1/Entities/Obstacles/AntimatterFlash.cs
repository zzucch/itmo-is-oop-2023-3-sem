using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class AntimatterFlash : IDenseNebulaObstacle
{
    private const int AntimatterPhotonDamage = 1;

    public ShipDeflectionResult Damage(ISpaceShip ship)
    {
        return ship.TakeDamage(new Damage(DamageType.Photon, AntimatterPhotonDamage));
    }
}