using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Vaklas : SpaceShip
{
    public Vaklas()
        : base(new ImpulseEngineE(), new GammaJumpEngine(), new DeflectorClass1(), new Hull.Hull(HullStrength.Class2, MassDimensional.Medium))
    {
    }
}