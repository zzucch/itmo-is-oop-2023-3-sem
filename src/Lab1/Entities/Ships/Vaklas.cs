using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Vaklas : SpaceShip
{
    public Vaklas()
        : base(
            new Engine(new ImpulseETravellingStrategy()),
            new Engine(new JumpGammaTravellingStrategy()),
            new Deflector(new PhysicalClass1DeflectionStrategy()),
            new Hull.Hull(new PhysicalClass2DeflectionStrategy(), MassDimensional.Medium))
    {
    }
}