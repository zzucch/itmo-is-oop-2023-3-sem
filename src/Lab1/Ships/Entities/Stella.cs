using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Deflection;
using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Stella : SpaceShip
{
    public Stella()
        : base(
            impulseEngine: new Engine(new ImpulseCTravellingStrategy()),
            jumpEngine: new Engine(new JumpOmegaTravellingStrategy()),
            new Deflector(new PhysicalClass1DeflectionStrategy()),
            new Hull(new PhysicalClass1DeflectionStrategy(), MassDimensional.Low))
    {
    }
}