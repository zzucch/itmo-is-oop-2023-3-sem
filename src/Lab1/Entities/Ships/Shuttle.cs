using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Shuttle : SpaceShip
{
    public Shuttle()
        : base(
            new ImpulseEngineC(),
            jumpEngine: null,
            deflector: null,
            new Hull.Hull(new PhysicalClass1DeflectionStrategy(), MassDimensional.Low))
    {
    }
}