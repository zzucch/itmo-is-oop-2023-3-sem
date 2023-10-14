using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Stella : SpaceShip
{
    public Stella()
        : base(
            impulseEngine: new Engine(new ImpulseCTravellingStrategy()),
            jumpEngine: new Engine(new JumpOmegaTravellingStrategy()),
            new Deflector(new PhysicalClass1DeflectionStrategy()),
            new Hull.Hull(new PhysicalClass1DeflectionStrategy(), MassDimensional.Low))
    {
    }
}