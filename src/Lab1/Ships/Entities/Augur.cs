using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Augur : SpaceShip
{
    public Augur(IDeflector? deflector = null)
        : base(
            impulseEngine: new Engine(new ImpulseETravellingStrategy()),
            jumpEngine: new Engine(new JumpAlphaTravellingStrategy()),
            deflector ?? new Deflector(new PhysicalClass3DeflectionStrategy()),
            new Hull(new PhysicalClass3DeflectionStrategy(), MassDimensional.High))
    {
    }
}