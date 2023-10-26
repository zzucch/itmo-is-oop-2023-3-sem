using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public abstract class SpaceShip : ISpaceShip
{
    protected SpaceShip(Engine? impulseEngine, Engine? jumpEngine, IDeflector? deflector, IHull hull)
    {
        ImpulseEngine = impulseEngine;
        JumpEngine = jumpEngine;
        Deflector = deflector;
        Hull = hull;
    }

    public Engine? ImpulseEngine { get; }
    public Engine? JumpEngine { get; }
    public CrewState CrewState { get; set; } = CrewState.Alive;
    private IDeflector? Deflector { get; }
    private IHull Hull { get; }

    public ShipDeflectionResult TakeDamage(Damage damage)
    {
        DeflectionResult? deflectorResult = Deflector?.TryDeflect(damage);
        if (deflectorResult?.Success is true)
        {
            return new ShipDeflectionResult(deflectorResult, HullResult: null);
        }

        DeflectionResult hullResult = Hull.TryDeflect(damage);
        if (hullResult.Success is false)
        {
            CrewState = CrewState.Dead;
        }

        return new ShipDeflectionResult(deflectorResult, hullResult);
    }
}