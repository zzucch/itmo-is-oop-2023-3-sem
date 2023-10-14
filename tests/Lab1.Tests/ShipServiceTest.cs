using System.Collections.Generic;
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
                distanceLightYear: 10000,
                obstacles: new List<IObstacle>(),
                EnvironmentType.DenseNebula),
        }));

        var launcher = new ShipLauncher(route);

        // Act
        IEnumerable<RouteSegmentResult> firstRouteResults = launcher.LaunchShip(shuttleWithNoJumpEngine);
        IEnumerable<RouteSegmentResult> secondRouteResults = launcher.LaunchShip(augurWithNotEnoughTravelDistance);

        // Assert
        Assert.Contains(
            firstRouteResults,
            filter: i => i.Success is false);
        Assert.Contains(
            secondRouteResults,
            filter: i => i.Success is false);
    }

    [Theory]
    [MemberData(nameof(SecondTestShips))]
    public void LaunchShip_ShouldOnlyCompleteWithSuccess_WhenShipHasPhotonDeflector(
        SpaceShip vaklasWithoutPhotonDeflector,
        SpaceShip vaklasWithPhotonDeflector)
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
                EnvironmentType.DenseNebula),
        }));
        vaklasWithPhotonDeflector.MakeDeflectorPhoton();

        var launcher = new ShipLauncher(route);

        // Act
        IEnumerable<RouteSegmentResult> firstRouteResults = launcher.LaunchShip(vaklasWithoutPhotonDeflector);
        IEnumerable<RouteSegmentResult> secondRouteResults = launcher.LaunchShip(vaklasWithPhotonDeflector);

        // Assert
        Assert.Contains(
            firstRouteResults,
            filter: i => i.CrewLost);
        Assert.DoesNotContain(
            secondRouteResults,
            filter: i => i.Success is false);
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
                EnvironmentType.NitriteNebula),
        }));

        var launcher = new ShipLauncher(route);

        // Act
        IEnumerable<RouteSegmentResult> firstRouteResults = launcher.LaunchShip(vaklas);
        IEnumerable<RouteSegmentResult> secondRouteResults = launcher.LaunchShip(augur);
        IEnumerable<RouteSegmentResult> thirdRouteResults = launcher.LaunchShip(meridian);

        // Assert
        Assert.Contains(
            firstRouteResults,
            filter: i => i.ShipDestroyed);
        Assert.Contains(
            secondRouteResults,
            filter: i => i is { Success: true, DeflectorDestroyed: true });
        Assert.DoesNotContain(
            thirdRouteResults,
            filter: i => i.Success is false);
    }

    [Theory]
    [MemberData(nameof(FourthTestShips))]
    public void ChooseShip_ShouldReturnShuttle_WhenShortRouteInNormalSpaceIsLaunched(
        ISpaceShip shuttle,
        ISpaceShip vaklas)
    {
        // Arrange
        var route = new Route(new List<RouteSegment>(new List<RouteSegment>()
        {
            new(
                distanceLightYear: 10,
                obstacles: new List<IObstacle>(),
                EnvironmentType.NormalSpace),
        }));
        const decimal activePlasmaCost = 100;
        const decimal gravitonMatterCost = 200;

        var chooser = new ShipChooser(route, activePlasmaCost, gravitonMatterCost);

        // Act
        ISpaceShip? chosenShip = chooser.ChooseShip(shuttle, vaklas);

        // Assert
        Assert.Equal(typeof(Shuttle), chosenShip?.GetType());
    }

    [Theory]
    [MemberData(nameof(FifthTestShips))]
    public void ChooseShip_ShouldReturnShipWithEnoughSubspaceTravelDistance_WhenMediumRouteInDenseNebulaIsLaunched(
        ISpaceShip augur,
        ISpaceShip stella)
    {
        // Arrange
        var route = new Route(new List<RouteSegment>(new List<RouteSegment>()
        {
            new(
                distanceLightYear: 100,
                obstacles: new List<IObstacle>(),
                EnvironmentType.DenseNebula),
        }));
        const decimal activePlasmaCost = 100;
        const decimal gravitonMatterCost = 200;

        var chooser = new ShipChooser(route, activePlasmaCost, gravitonMatterCost);

        // Act
        ISpaceShip? chosenShip = chooser.ChooseShip(augur, stella);

        // Assert
        Assert.True(chosenShip is Stella);
    }

    [Theory]
    [MemberData(nameof(SixthTestShips))]
    public void ChooseShip_ShouldReturnMoreAdvancedShip_WhenRouteInNitriteParticleNebulaIsLaunched(
        ISpaceShip shuttle,
        ISpaceShip vaklas)
    {
        // Arrange
        var route = new Route(new List<RouteSegment>(new List<RouteSegment>()
        {
            new(
                distanceLightYear: 100,
                obstacles: new List<IObstacle>(),
                EnvironmentType.NitriteNebula),
        }));
        const decimal activePlasmaCost = 100;
        const decimal gravitonMatterCost = 200;

        var chooser = new ShipChooser(route, activePlasmaCost, gravitonMatterCost);

        // Act
        ISpaceShip? chosenShip = chooser.ChooseShip(shuttle, vaklas);

        // Assert
        Assert.True(chosenShip is Vaklas);
    }

    [Fact]
    public void LaunchShip_ShouldCompleteWithSuccess_WhenTravellingLongPassableRoute()
    {
        // Arrange
        SpaceShip ship = new Meridian();
        ship.MakeDeflectorPhoton();

        var route = new Route(
            new List<RouteSegment>(new List<RouteSegment>()
            {
                new(
                    distanceLightYear: 10000000,
                    obstacles: new List<IObstacle>
                    {
                        new Asteroid(),
                    },
                    EnvironmentType.NormalSpace),
                new(
                    distanceLightYear: 10000,
                    obstacles: new List<IObstacle>(),
                    EnvironmentType.DenseNebula),
                new(
                    distanceLightYear: 10000,
                    obstacles: new List<IObstacle>(),
                    EnvironmentType.NitriteNebula),
                new(
                    distanceLightYear: 1000000,
                    obstacles: new List<IObstacle>
                    {
                        new Asteroid(),
                    },
                    EnvironmentType.NormalSpace),
                new(
                    distanceLightYear: 10000,
                    obstacles: new List<IObstacle>
                    {
                        new AntimatterFlash(),
                    },
                    EnvironmentType.DenseNebula),
                new(
                    distanceLightYear: 10000,
                    obstacles: new List<IObstacle>(),
                    EnvironmentType.NitriteNebula),
            }));
        var launcher = new ShipLauncher(route);

        // Act
        IEnumerable<RouteSegmentResult> routeSegmentResults = launcher.LaunchShip(ship);

        // Assert
        Assert.DoesNotContain(
            routeSegmentResults,
            filter: i => i.Success is false);
    }
}