using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Vaklas : SpaceShip
{
    public Vaklas()
        : base(new ImpulseEngineE(), new GammaJumpEngine(), new DeflectorClass1(), new Hull(HullStrength.Class2, MassDimensional.Medium))
    {
    }
}