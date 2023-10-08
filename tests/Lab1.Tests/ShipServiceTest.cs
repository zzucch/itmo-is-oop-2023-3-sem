using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShipServiceTest
{
    public static IEnumerable<object[]> FirstTestShips()
    {
        yield return new object[]
        {
            new Shuttle(100),
            new Augur(100),
            new Route(new List<RouteSegment>(new List<RouteSegment>()
            {
                new(
                    distanceLightYear: 100,
                    obstacles: new List<IObstacle>(),
                    Environment.DenseNebula),
            })),
        };
    }

    public static IEnumerable<object[]> SecondTestShips()
    {
        yield return new object[]
        {
            new Vaklas(100),
            new Vaklas(100),
            new Route(new List<RouteSegment>(new List<RouteSegment>()
            {
                new(
                    distanceLightYear: 100,
                    obstacles: new List<IObstacle>()
                    {
                        new AntimatterFlash(),
                    },
                    Environment.DenseNebula),
            })),
        };
    }

    public static IEnumerable<object[]> ThirdTestShips()
    {
        yield return new object[]
        {
            new Vaklas(100),
            new Augur(100),
            new Meridian(100),
            new Route(new List<RouteSegment>(new List<RouteSegment>()
            {
                new(
                    distanceLightYear: 100,
                    obstacles: new List<IObstacle>()
                    {
                        new SpaceWhales(),
                    },
                    Environment.NitriteNebula),
            })),
        };
    }

    public static IEnumerable<object[]> FourthTestShips()
    {
        yield return new object[]
        {
            new Shuttle(100),
            new Vaklas(100),
            new Route(new List<RouteSegment>(new List<RouteSegment>()
            {
                new(
                    distanceLightYear: 10,
                    obstacles: new List<IObstacle>(),
                    Environment.NormalSpace),
            })),
        };
    }

    public static IEnumerable<object[]> FifthTestShips()
    {
        yield return new object[]
        {
            new Augur(100),
            new Stella(100),
            new Route(new List<RouteSegment>(new List<RouteSegment>()
            {
                new(
                    distanceLightYear: 100,
                    obstacles: new List<IObstacle>(),
                    Environment.DenseNebula),
            })),
        };
    }

    public static IEnumerable<object[]> SixthTestShips()
    {
        yield return new object[]
        {
            new Shuttle(100),
            new Vaklas(100),
            new Route(new List<RouteSegment>(new List<RouteSegment>()
            {
                new(
                    distanceLightYear: 100,
                    obstacles: new List<IObstacle>(),
                    Environment.NitriteNebula),
            })),
        };
    }

    public static IEnumerable<object[]> SeventhTestShips()
    {
        yield return System.Array.Empty<object>();
    }

    [Theory]
    [MemberData(nameof(FirstTestShips))]
    public void LaunchShip_ShouldNotCompleteWithSuccess_WhenNoJumpEngineOrNotEnoughSubspaceTravelDistanceInDenseNebula(
        ISpaceShip shuttleWithNoJumpEngine,
        ISpaceShip augurWithNotEnoughTravelDistance,
        Route route)
    {
        IReadOnlyCollection<RouteSegmentResult> firstRouteResults = ShipService.LaunchShip(shuttleWithNoJumpEngine, route);
        IReadOnlyCollection<RouteSegmentResult> secondRouteResults = ShipService.LaunchShip(augurWithNotEnoughTravelDistance, route);

        Assert.False(
            condition: firstRouteResults.All(i => i.Success),
            userMessage: "route should end in failure because shuttle doesn't have jump engine");
        Assert.False(
            condition: secondRouteResults.All(i => i.Success),
            userMessage: "route should end in failure because augur's engine's max subspace travel distance is not enough");
    }

    [Theory]
    [MemberData(nameof(SecondTestShips))]
    public void Idk2(ISpaceShip vaklasWithoutPhotonDeflector, ISpaceShip vaklasWithPhotonDeflector, Route route)
    {
    }

    [Theory]
    [MemberData(nameof(ThirdTestShips))]
    public void Idk3(ISpaceShip vaklas, ISpaceShip augur, ISpaceShip meridian, Route route)
    {
        IReadOnlyCollection<RouteSegmentResult> firstRouteResults = ShipService.LaunchShip(vaklas, route);
        IReadOnlyCollection<RouteSegmentResult> secondRouteResults = ShipService.LaunchShip(augur, route);
        IReadOnlyCollection<RouteSegmentResult> thirdRouteResults = ShipService.LaunchShip(meridian, route);

        Assert.True(
            condition: firstRouteResults.Any(i => i.ShipDestroyed),
            userMessage: "vaklas should be destroyed after facing space whales");
        Assert.True(
            condition: secondRouteResults.All(i => i.Success) &&
                       secondRouteResults.Any(i => i.FacedObstacle),
            userMessage: "augur shouldn't be destroyed after facing space whales, only deflectors should be destroyed");
        Assert.False(
            condition: thirdRouteResults.All(i => i.FacedObstacle),
            userMessage: "meridian should not face any obstacle");
    }

    [Theory]
    [MemberData(nameof(FourthTestShips))]
    public void Idk4(ISpaceShip shuttle, ISpaceShip vaklas, Route route)
    {
        IReadOnlyCollection<RouteSegmentResult> firstRouteResults = ShipService.LaunchShip(shuttle, route);
        IReadOnlyCollection<RouteSegmentResult> secondRouteResults = ShipService.LaunchShip(vaklas, route);

        // todo
        Assert.True(true);
    }

    [Theory]
    [MemberData(nameof(FifthTestShips))]
    public void Idk5(ISpaceShip augur, ISpaceShip stella, Route route)
    {
        IReadOnlyCollection<RouteSegmentResult> firstRouteResults = ShipService.LaunchShip(augur, route);
        IReadOnlyCollection<RouteSegmentResult> secondRouteResults = ShipService.LaunchShip(stella, route);

        // todo
        Assert.True(true);
    }

    [Theory]
    [MemberData(nameof(SixthTestShips))]
    public void Idk6(ISpaceShip shuttle, ISpaceShip vaklas, Route route)
    {
        IReadOnlyCollection<RouteSegmentResult> firstRouteResults = ShipService.LaunchShip(shuttle, route);
        IReadOnlyCollection<RouteSegmentResult> secondRouteResults = ShipService.LaunchShip(vaklas, route);

        // todo
        Assert.True(true);
    }
}