using System;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public abstract class SpaceShip : ISpaceShip
{
    protected SpaceShip(Engine? impulseEngine, Engine? jumpEngine, IDeflector? deflector, Hull hull)
    {
        ImpulseEngine = impulseEngine;
        JumpEngine = jumpEngine;
        Deflector = deflector;
        Hull = hull;
    }

    private Engine? ImpulseEngine { get; }
    private Engine? JumpEngine { get; }
    private IDeflector? Deflector { get; }
    private Hull Hull { get; }
    private CrewState CrewState { get; set; } = CrewState.Alive;

    public ShipTravelResult Travel(IRouteSegment routeSegment)
    {
        TravelResult? impulseTravelResult = ImpulseEngine?.TryTravel(routeSegment.DistanceLightYear, routeSegment.EnvironmentType);
        TravelResult? jumpTravelResult = JumpEngine?.TryTravel(routeSegment.DistanceLightYear, routeSegment.EnvironmentType);

        if (impulseTravelResult?.Success is true)
        {
            if (jumpTravelResult is null || jumpTravelResult.Success is false)
            {
                return new ShipTravelResult(impulseTravelResult, CrewState);
            }

            return new ShipTravelResult(jumpTravelResult, CrewState);
        }

        if (jumpTravelResult?.Success is true)
        {
            return new ShipTravelResult(jumpTravelResult, CrewState);
        }

        return new ShipTravelResult(
            new TravelResult(
                Success: false,
                TravelTimeTaken: TimeSpan.Zero,
                FuelConsumed: new Fuel(FuelType.None, 0.0),
                ShipLost: false),
            CrewState);
    }

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