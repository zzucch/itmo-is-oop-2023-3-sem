using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Stella : SpaceShip
{
    public Stella()
        : base(
            new ImpulseEngineC(),
            new OmegaJumpEngine(),
            new Deflector(new PhysicalClass1DeflectionStrategy()),
            new Hull.Hull(new PhysicalClass1DeflectionStrategy(), MassDimensional.Low))
    {
    }
}