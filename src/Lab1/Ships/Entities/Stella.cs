using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Stella : SpaceShip
{
    public Stella()
        : base(new ImpulseEngineC(), new OmegaJumpEngine(), new DeflectorClass1(), new Hull(HullStrength.Class1, MassDimensional.Low))
    {
    }
}