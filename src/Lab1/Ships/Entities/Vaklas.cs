using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.TravellingStrategies;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Vaklas : SpaceShip
{
    public Vaklas(IDeflector? deflector = null)
        : base(
            impulseEngine: new Engine(new ImpulseETravellingStrategy()),
            jumpEngine: new Engine(new JumpGammaTravellingStrategy()),
            deflector ?? new Deflector(new PhysicalClass1DeflectionStrategy()),
            new Hull(new PhysicalClass2DeflectionStrategy()))
    {
    }
}