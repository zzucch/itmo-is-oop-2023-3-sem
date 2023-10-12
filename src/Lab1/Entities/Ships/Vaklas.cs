using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Vaklas : SpaceShip
{
    public Vaklas()
        : base(new ImpulseEngineE(), new GammaJumpEngine(), new Deflector(new PhysicalClass1DeflectionStrategy()), new Hull.Hull(HullStrength.Class2, MassDimensional.Medium))
    {
    }
}