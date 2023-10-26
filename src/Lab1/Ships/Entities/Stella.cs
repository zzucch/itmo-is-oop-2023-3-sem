using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.TravellingStrategies;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Stella : SpaceShip
{
    public Stella(IDeflector? deflector = null)
        : base(
            impulseEngine: new Engine(new ImpulseCTravellingStrategy()),
            jumpEngine: new Engine(new JumpOmegaTravellingStrategy()),
            deflector ?? new Deflector(new PhysicalClass1DeflectionStrategy()),
            new Hull(new PhysicalClass1DeflectionStrategy(), MassDimensional.Low))
    {
    }
}