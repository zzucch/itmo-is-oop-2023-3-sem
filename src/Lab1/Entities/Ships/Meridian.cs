using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Meridian : SpaceShip, IEmitterSpaceShip
{
    public Meridian()
        : base(
            impulseEngine: new Engine(new ImpulseETravellingStrategy()),
            jumpEngine: new Engine(new JumpGammaTravellingStrategy()),
            new Deflector(new PhysicalClass2DeflectionStrategy()),
            new Hull.Hull(new PhysicalClass2DeflectionStrategy(), MassDimensional.Medium))
    {
    }
}