using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.TravellingStrategies;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Meridian : SpaceShip, IEmitterSpaceShip
{
    public Meridian(IDeflector? deflector = null)
        : base(
            impulseEngine: new Engine(new ImpulseETravellingStrategy()),
            jumpEngine: new Engine(new JumpGammaTravellingStrategy()),
            deflector ?? new Deflector(new PhysicalClass2DeflectionStrategy()),
            new Hull(new PhysicalClass2DeflectionStrategy(), MassDimensional.Medium))
    {
    }
}