using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public abstract class SpaceShip : ISpaceShip
{
    protected SpaceShip(IEngine? impulseEngine, IEngine? jumpEngine, IDeflector? deflector, Hull.Hull hull)
    {
        ImpulseEngine = impulseEngine;
        JumpEngine = jumpEngine;
        Deflector = deflector;
        Hull = hull;
    }

    protected IEngine? ImpulseEngine { get; init; }
    protected IEngine? JumpEngine { get; init; }
    private IDeflector? Deflector { get; init; }
    private Hull.Hull Hull { get; init; }
    private CrewState CrewState { get; set; } = CrewState.Alive;

    public RouteSegmentResult Travel(RouteSegment routeSegment)
    {
        throw new NotImplementedException();
    }

    public void TakePhysicalDamage(int damage)
    {
        if (Deflector != null && Deflector.TryPhysicalDeflect(damage))
        {
            return;
        }

        if (!Hull.TryHullDeflect(damage))
        {
            CrewState = CrewState.Dead;
        }
    }

    public void TakePhotonDamage()
    {
        if (Deflector is not null && Deflector.TryPhotonDeflect())
        {
            return;
        }

        CrewState = CrewState.Dead;
    }
}