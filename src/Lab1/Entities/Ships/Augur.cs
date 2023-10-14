using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Augur : SpaceShip
{
    public Augur()
        : base(
            impulseEngine: new Engine(new ImpulseETravellingStrategy()),
            jumpEngine: new Engine(new JumpAlphaTravellingStrategy()),
            new Deflector(new PhysicalClass3DeflectionStrategy()),
            new Hull.Hull(new PhysicalClass3DeflectionStrategy(), MassDimensional.High))
    {
    }
}