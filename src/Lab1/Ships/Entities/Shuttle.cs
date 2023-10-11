using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public class Shuttle : SpaceShip
{
    public Shuttle()
        : base(new ImpulseEngineC(), jumpEngine: null, deflector: null, new Hull(HullStrength.Class1, MassDimensional.Low))
    {
    }
}