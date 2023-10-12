using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Augur : SpaceShip
{
    public Augur()
        : base(new ImpulseEngineE(), new AlphaJumpEngine(), new DeflectorClass3(), new Hull.Hull(HullStrength.Class3, MassDimensional.High))
    {
    }
}