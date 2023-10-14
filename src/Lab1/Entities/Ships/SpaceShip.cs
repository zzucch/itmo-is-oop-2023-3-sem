using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Damage;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public abstract class SpaceShip : ISpaceShip
{
    protected SpaceShip(Engine? impulseEngine, Engine? jumpEngine, IDeflector? deflector, Hull.Hull hull)
    {
        ImpulseEngine = impulseEngine;
        JumpEngine = jumpEngine;
        Deflector = deflector;
        Hull = hull;
    }

    private Engine? ImpulseEngine { get; }
    private Engine? JumpEngine { get; }
    private IDeflector? Deflector { get; set; }
    private Hull.Hull Hull { get; }
    private CrewState CrewState { get; set; } = CrewState.Alive;

    public void MakeDeflectorPhoton()
    {
        if (Deflector is not null)
        {
            Deflector = new PhotonDeflector(Deflector);
        }
    }

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
                FuelTypeConsumed: Fuel.ActivePlasma,
                TravelFuelConsumption: 0D,
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