using Itmo.ObjectOrientedProgramming.Lab1.Damage.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Obstacles;

public class AntimatterFlash : IDenseNebulaObstacle
{
    private const int AntimatterPhotonDamage = 1;

    public ShipDeflectionResult Damage(ISpaceShip ship)
    {
        return ship.TakeDamage(new Models.Damage(DamageType.Photon, AntimatterPhotonDamage));
    }
}