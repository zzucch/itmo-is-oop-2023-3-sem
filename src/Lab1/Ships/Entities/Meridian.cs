using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Meridian : SpaceShip, IEmitterSpaceShip
{
    public Meridian()
        : base(
            impulseEngine: new Engine(new ImpulseETravellingStrategy()),
            jumpEngine: new Engine(new JumpGammaTravellingStrategy()),
            new Deflector(new PhysicalClass2DeflectionStrategy()),
            new Hull(new PhysicalClass2DeflectionStrategy(), MassDimensional.Medium))
    {
    }
}