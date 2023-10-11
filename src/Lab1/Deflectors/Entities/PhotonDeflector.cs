using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;

public class PhotonDeflector : DeflectorDecorator
{
    public PhotonDeflector(Deflector deflector)
        : base(deflector)
    {
    }

    private int Charge { get; set; } = 3;

    public override bool TryPhotonDeflect(IObstacle obstacle)
    {
        if (Charge > 0)
        {
            Charge -= 1;
        }

        return Charge > 0;
    }
}