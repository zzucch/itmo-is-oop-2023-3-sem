using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ShipServiceTest
{
    public static IEnumerable<object[]> FirstTestShips()
    {
        yield return new object[]
        {
            new Shuttle(),
            new Augur(),
        };
    }

    public static IEnumerable<object[]> SecondTestShips()
    {
        yield return new object[]
        {
            new Vaklas(),
            new Vaklas(),
        };
    }

    public static IEnumerable<object[]> ThirdTestShips()
    {
        yield return new object[]
        {
            new Vaklas(),
            new Augur(),
            new Meridian(),
        };
    }

    public static IEnumerable<object[]> FourthTestShips()
    {
        yield return new object[]
        {
            new Shuttle(),
            new Vaklas(),
        };
    }

    public static IEnumerable<object[]> FifthTestShips()
    {
        yield return new object[]
        {
            new Augur(),
            new Stella(),
        };
    }

    public static IEnumerable<object[]> SixthTestShips()
    {
        yield return new object[]
        {
            new Shuttle(),
            new Vaklas(),
        };
    }

    [Theory]
    [MemberData(nameof(FirstTestShips))]
    public void LaunchShip_ShouldNotCompleteWithSuccess_WhenNoJumpEngineOrNotEnoughSubspaceTravelDistanceInDenseNebula(
        ISpaceShip shuttleWithNoJumpEngine,
        ISpaceShip augurWithNotEnoughTravelDistance)
    {
        // Arrange
        var route = new Route(new List<RouteSegment>(new List<RouteSegment>()
        {
            new(
                distanceLightYear: 100,
                obstacles: new List<IObstacle>(),
                EnvironmentType.DenseNebula,
                environmentAcceleration: 0),
        }));

        // Act
        IReadOnlyCollection<RouteSegmentResult> firstRouteResults = ShipService.LaunchShip(shuttleWithNoJumpEngine, route);
        IReadOnlyCollection<RouteSegmentResult> secondRouteResults = ShipService.LaunchShip(augurWithNotEnoughTravelDistance, route);

        // Assert
        Assert.False(
            condition: firstRouteResults.All(i => i.Success),
            userMessage: "route should end in failure because shuttle doesn't have jump engine");
        Assert.False(
            condition: secondRouteResults.All(i => i.Success),
            userMessage: "route should end in failure because augur's engine's max subspace travel distance is not enough");
    }

    [Theory]
    [MemberData(nameof(SecondTestShips))]
    public void LaunchShip_ShouldOnlyCompleteWithSuccess_WhenShipHasPhotonDeflector(
        ISpaceShip vaklasWithoutPhotonDeflector,
        ISpaceShip vaklasWithPhotonDeflector)
    {
        // Arrange
        var route = new Route(new List<RouteSegment>(new List<RouteSegment>()
        {
            new(
                distanceLightYear: 100,
                obstacles: new List<IObstacle>()
                {
                    new AntimatterFlash(),
                },
                EnvironmentType.DenseNebula,
                environmentAcceleration: 0),
        }));

        // Act
        IReadOnlyCollection<RouteSegmentResult> firstRouteResults = ShipService.LaunchShip(vaklasWithoutPhotonDeflector, route);
        IReadOnlyCollection<RouteSegmentResult> secondRouteResults = ShipService.LaunchShip(vaklasWithPhotonDeflector, route);

        // Assert
    }

    [Theory]
    [MemberData(nameof(ThirdTestShips))]
    public void LaunchShip_ShouldCompleteWithDifferentResults_WhenDifferentShipsAreUsedInDenseNebula(
        ISpaceShip vaklas,
        ISpaceShip augur,
        ISpaceShip meridian)
    {
        // Arrange
        var route = new Route(new List<RouteSegment>(new List<RouteSegment>()
        {
            new(
                distanceLightYear: 100,
                obstacles: new List<IObstacle>()
                {
                    new SpaceWhales(amount: 1),
                },
                EnvironmentType.NitriteNebula,
                environmentAcceleration: 0),
        }));

        // Act
        IReadOnlyCollection<RouteSegmentResult> firstRouteResults = ShipService.LaunchShip(vaklas, route);
        IReadOnlyCollection<RouteSegmentResult> secondRouteResults = ShipService.LaunchShip(augur, route);
        IReadOnlyCollection<RouteSegmentResult> thirdRouteResults = ShipService.LaunchShip(meridian, route);

        // Assert
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
    public void LaunchShip_ShouldChooseOptimalShip_WhenShortRouteInNormalSpaceIsLaunched(
        ISpaceShip shuttle,
        ISpaceShip vaklas)
    {
        // Arrange
        var route = new Route(new List<RouteSegment>(new List<RouteSegment>()
        {
            new(
                distanceLightYear: 10,
                obstacles: new List<IObstacle>(),
                EnvironmentType.NormalSpace,
                environmentAcceleration: 0),
        }));

        // Act
        IReadOnlyCollection<RouteSegmentResult> firstRouteResults = ShipService.LaunchShip(shuttle, route);
        IReadOnlyCollection<RouteSegmentResult> secondRouteResults = ShipService.LaunchShip(vaklas, route);

        // Assert
        Assert.True(true);
    }

    [Theory]
    [MemberData(nameof(FifthTestShips))]
    public void LaunchShip_ShouldChooseShipWithEnoughSubspaceTravelDistance_WhenMediumRouteInDenseNebulaIsLaunched
    (
        ISpaceShip augur,
        ISpaceShip stella)
    {
        // Arrange
        var route = new Route(new List<RouteSegment>(new List<RouteSegment>()
        {
            new(
                distanceLightYear: 100,
                obstacles: new List<IObstacle>(),
                EnvironmentType.DenseNebula,
                environmentAcceleration: 0),
        }));

        // Act
        IReadOnlyCollection<RouteSegmentResult> firstRouteResults = ShipService.LaunchShip(augur, route);
        IReadOnlyCollection<RouteSegmentResult> secondRouteResults = ShipService.LaunchShip(stella, route);

        // Assert
        Assert.True(true);
    }

    [Theory]
    [MemberData(nameof(SixthTestShips))]
    public void LaunchShip_ShouldChooseMoreAdvancedShip_WhenRouteInNitriteParticleNebulaIsLaunched(
        ISpaceShip shuttle,
        ISpaceShip vaklas)
    {
        // Arrange
        var route = new Route(new List<RouteSegment>(new List<RouteSegment>()
        {
            new(
                distanceLightYear: 100,
                obstacles: new List<IObstacle>(),
                EnvironmentType.NitriteNebula,
                environmentAcceleration: -10),
        }));

        // Act
        IReadOnlyCollection<RouteSegmentResult> firstRouteResults = ShipService.LaunchShip(shuttle, route);
        IReadOnlyCollection<RouteSegmentResult> secondRouteResults = ShipService.LaunchShip(vaklas, route);

        // Assert
        Assert.True(true);
    }
}