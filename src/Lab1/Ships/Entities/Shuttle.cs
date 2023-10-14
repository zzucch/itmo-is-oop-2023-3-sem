using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities;

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