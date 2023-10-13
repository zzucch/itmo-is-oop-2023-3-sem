using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class PhotonDeflector : DeflectorDecorator
{
    private const DamageType DeflectionType = DamageType.Photon;

    public PhotonDeflector(IDeflector deflector)
        : base(deflector)
    {
    }

    private IDeflectionStrategy PhotonDeflectionStrategy { get; set; } = new PhotonDeflectionStrategy();
    private int PhotonHitPoints { get; set; } = 3;

    public override DeflectionResult TryDeflect(Damage damage)
    {
        if (damage.Type is not DeflectionType)
        {
            return base.TryDeflect(damage);
        }

        (bool success, int photonHitPoints) = PhotonDeflectionStrategy.TryDeflect(damage, PhotonHitPoints);
        bool damageTaken = (PhotonHitPoints - photonHitPoints) > 0;

        return new DeflectionResult(success, damageTaken);
    }
}