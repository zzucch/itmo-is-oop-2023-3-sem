using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Meridian : SpaceShip
{
    public Meridian()
        : base(new ImpulseEngineE(), new GammaJumpEngine(), new DeflectorClass2(), new Hull(HullStrength.Class2, MassDimensional.Medium))
    {
    }
}