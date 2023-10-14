using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.DeflectionStrategies;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.TravellingStrategies;

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