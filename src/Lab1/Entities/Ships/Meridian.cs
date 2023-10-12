using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Meridian : SpaceShip
{
    public Meridian()
        : base(
            new ImpulseEngineE(),
            new GammaJumpEngine(),
            new Deflector(new PhysicalClass2DeflectionStrategy()),
            new Hull.Hull(new PhysicalClass2DeflectionStrategy(), MassDimensional.Medium))
    {
    }
}