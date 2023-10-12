using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Stella : SpaceShip
{
    public Stella()
        : base(new ImpulseEngineC(), new OmegaJumpEngine(), new DeflectorClass1(), new Hull.Hull(HullStrength.Class1, MassDimensional.Low))
    {
    }
}