using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Augur : SpaceShip
{
    public Augur()
        : base(new ImpulseEngineE(), new AlphaJumpEngine(), new DeflectorClass3(), new Hull(HullStrength.Class3, MassDimensional.High))
    {
    }
}