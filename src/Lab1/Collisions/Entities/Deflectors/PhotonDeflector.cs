using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;

public class PhotonDeflector : DeflectorDecorator
{
    private const DamageType DeflectionType = DamageType.Photon;
    private readonly IDeflectionStrategy _photonDeflectionStrategy = new PhotonDeflectionStrategy();

    public PhotonDeflector(IDeflector deflector)
        : base(deflector)
    {
    }

    private int PhotonHitPoints { get; set; } = 3;

    public override DeflectionResult TryDeflect(Damage damage)
    {
        if (damage.Type is not DeflectionType)
        {
            return base.TryDeflect(damage);
        }

        (bool success, PhotonHitPoints) = _photonDeflectionStrategy.TryDeflect(damage, PhotonHitPoints);
        bool deflectorDestroyed = PhotonHitPoints == 0;

        return new DeflectionResult(success, deflectorDestroyed);
    }
}