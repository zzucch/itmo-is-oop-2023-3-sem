using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Meridian : SpaceShip
{
    public Meridian()
        : base(new ImpulseEngineE(), new GammaJumpEngine(), new DeflectorClass2(), new Hull.Hull(HullStrength.Class2, MassDimensional.Medium))
    {
    }
}