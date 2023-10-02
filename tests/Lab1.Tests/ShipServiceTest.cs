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
        yield return new object[] { new Shuttle(100), new Augur(100) };
    }

    [Theory]
    [MemberData(nameof(FirstTestShips))]
    public void LaunchShip_ShouldNotCompleteWithSuccess_WhenNoJumpEngineOrNotEnoughSubspaceTravelDistanceInDenseNebula(
        ISpaceShip first,
        ISpaceShip second)
    {
        var route = new Route(new List<RouteSegment>(new List<RouteSegment>()
        {
            new(
                length: 100,
                obstacles: new List<IObstacle>(),
                Environment.DenseNebula),
        }));

        IReadOnlyCollection<RouteSegmentResult> firstRouteResults = ShipService.LaunchShip(first, route);
        IReadOnlyCollection<RouteSegmentResult> secondRouteResults = ShipService.LaunchShip(second, route);

        Assert.False(
            condition: firstRouteResults.All(i => i.Success),
            userMessage: "route should end in failure because first ship doesn't have jump engines");
        Assert.False(
            condition: secondRouteResults.All(i => i.Success),
            userMessage: "route should end in failure because second ship's engine's max length of subspace travel distance is not enough");
    }
}