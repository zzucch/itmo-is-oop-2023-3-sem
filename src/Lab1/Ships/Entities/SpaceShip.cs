using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public abstract class SpaceShip : ISpaceShip
{
    private readonly IDeflector? _deflector;
    private readonly IHull _hull;

    protected SpaceShip(Engine? impulseEngine, Engine? jumpEngine, IDeflector? deflector, IHull hull)
    {
        ImpulseEngine = impulseEngine;
        JumpEngine = jumpEngine;
        _deflector = deflector;
        _hull = hull;
    }

    public Engine? ImpulseEngine { get; }
    public Engine? JumpEngine { get; }
    public CrewState CrewState { get; private set; } = CrewState.Alive;

    public ShipDeflectionResult TakeDamage(Damage damage)
    {
        DeflectionResult? deflectorResult = _deflector?.TryDeflect(damage);
        if (deflectorResult?.Success is true)
        {
            return new ShipDeflectionResult(deflectorResult, HullResult: null);
        }

        DeflectionResult hullResult = _hull.TryDeflect(damage);
        if (hullResult.Success is false)
        {
            CrewState = CrewState.Dead;
        }

        return new ShipDeflectionResult(deflectorResult, hullResult);
    }
}