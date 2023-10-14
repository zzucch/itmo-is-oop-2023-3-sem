using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Shuttle : SpaceShip
{
    public Shuttle()
        : base(
            impulseEngine: new Engine(new ImpulseCTravellingStrategy()),
            jumpEngine: null,
            deflector: null,
            new Hull(new PhysicalClass1DeflectionStrategy(), MassDimensional.Low))
    {
    }
}