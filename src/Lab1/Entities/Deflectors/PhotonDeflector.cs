using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;

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

    public override bool TryDeflect(Damage damage)
    {
        if (damage.Type is not DeflectionType)
        {
            return base.TryDeflect(damage);
        }

        (bool success, PhotonHitPoints) = PhotonDeflectionStrategy.TryDeflect(damage, PhotonHitPoints);

        return success;
    }
}