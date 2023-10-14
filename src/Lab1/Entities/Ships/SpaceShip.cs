using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

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
    private CrewState CrewState { get; } = CrewState.Alive;

    public void MakeDeflectorPhoton()
    {
        if (Deflector is not null)
        {
            Deflector = new PhotonDeflector(Deflector);
        }
    }

    public ShipTravelResult Travel(RouteSegment routeSegment)
    {
        TravelResult? impulseTravelResult = ImpulseEngine?.TryTravel(routeSegment.DistanceLightYear, routeSegment.EnvironmentType);
        TravelResult? jumpTravelResult = JumpEngine?.TryTravel(routeSegment.DistanceLightYear, routeSegment.EnvironmentType);

        if (impulseTravelResult is not null && impulseTravelResult.Success)
        {
            if (jumpTravelResult?.Success is false)
            {
                return new ShipTravelResult(impulseTravelResult, CrewState);
            }

            if (jumpTravelResult is not null)
            {
                return new ShipTravelResult(jumpTravelResult, CrewState);
            }
        }

        if (jumpTravelResult?.Success is true)
        {
            return new ShipTravelResult(jumpTravelResult, CrewState);
        }

        return new ShipTravelResult(
            new TravelResult(
                Success: false,
                TravelTimeTaken: 0D,
                FuelTypeConsumed: Fuel.ActivePlasma,
                TravelFuelConsumption: 0D,
                ShipLost: false),
            CrewState);
    }

    public ShipDeflectionResult TakeDamage(Damage damage)
    {
        DeflectionResult? deflectorResult = Deflector?.TryDeflect(damage);
        if (deflectorResult is null || deflectorResult.Success is false)
        {
            DeflectionResult hullResult = Hull.TryDeflect(damage);
            return new ShipDeflectionResult(deflectorResult, hullResult);
        }

        return new ShipDeflectionResult(deflectorResult, HullResult: null);
    }
}