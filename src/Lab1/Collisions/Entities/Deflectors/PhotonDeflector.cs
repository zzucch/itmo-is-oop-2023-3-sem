using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;

public class PhotonDeflector : DeflectorDecorator
{
    private const DamageType DeflectionType = DamageType.Photon;

    public PhotonDeflector(IDeflector deflector)
        : base(deflector)
    {
    }

    private int PhotonHitPoints { get; set; } = 3;
    private IDeflectionStrategy PhotonDeflectionStrategy { get; } = new PhotonDeflectionStrategy();

    public override DeflectionResult TryDeflect(Damage damage)
    {
        if (damage.Type is not DeflectionType)
        {
            return base.TryDeflect(damage);
        }

        (bool success, PhotonHitPoints) = PhotonDeflectionStrategy.TryDeflect(damage, PhotonHitPoints);
        bool deflectorDestroyed = PhotonHitPoints == 0;

        return new DeflectionResult(success, deflectorDestroyed);
    }
}