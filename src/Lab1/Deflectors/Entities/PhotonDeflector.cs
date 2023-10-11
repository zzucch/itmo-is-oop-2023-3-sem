namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class PhotonDeflector : DeflectorDecorator
{
    public PhotonDeflector(Deflector deflector)
        : base(deflector)
    {
    }

    private int PhotonDeflectionCharge { get; set; } = 3;

    public override bool TryPhotonDeflect()
    {
        if (PhotonDeflectionCharge > 0)
        {
            PhotonDeflectionCharge--;
        }

        return PhotonDeflectionCharge > 0;
    }
}