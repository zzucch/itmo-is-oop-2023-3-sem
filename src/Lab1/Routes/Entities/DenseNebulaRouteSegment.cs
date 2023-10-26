using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;

public class DenseNebulaRouteSegment : IRouteSegment
{
    public DenseNebulaRouteSegment(int distanceLightYear, IEnumerable<IDenseNebulaObstacle> obstacles, int acceleration = 0)
    {
        DistanceLightYear = distanceLightYear;
        Obstacles = obstacles;
        Acceleration = acceleration;
    }

    public IEnumerable<IObstacle> Obstacles { get; }
    public EnvironmentType EnvironmentType => EnvironmentType.DenseNebula;
    public int DistanceLightYear { get; }
    public int Acceleration { get; }

    public RouteSegmentResult BeTravelled(ISpaceShip ship)
    {
        if (ship.JumpEngine is null)
        {
            return new RouteSegmentResult(
                Success: false,
                FuelConsumed: new Fuel(FuelType.None, 0.0),
                TimeTaken: TimeSpan.Zero,
                ShipLost: false,
                CrewLost: false,
                ShipDestroyed: false,
                DeflectorDestroyed: false);
        }

        var shipDeflectionResults = Obstacles.Select(obstacle => obstacle.Damage(ship)).ToList();

        (bool travelSuccess, TimeSpan timeTaken, Fuel? fuelConsumed, bool shipLost)
            = ship.JumpEngine.TryTravel(DistanceLightYear, EnvironmentType, Acceleration);

        bool success = travelSuccess && shipDeflectionResults.All(result =>
            (result.DeflectorResult is null && result.HullResult is null)
            || (result.DeflectorResult is not null && result.DeflectorResult.Success)
            || (result.HullResult is not null && result.HullResult.Success));

        bool crewLost = ship.CrewState is CrewState.Dead;

        bool shipDestroyed = shipDeflectionResults.Any(
            result => result.HullResult is not null && result.HullResult.DeflectingEntityDestroyed);

        bool deflectorDestroyed = shipDeflectionResults.Any(
            result => result.DeflectorResult is not null && result.DeflectorResult.DeflectingEntityDestroyed);

        return new RouteSegmentResult(
            success,
            fuelConsumed,
            timeTaken,
            shipLost,
            crewLost,
            shipDestroyed,
            deflectorDestroyed);
    }
}