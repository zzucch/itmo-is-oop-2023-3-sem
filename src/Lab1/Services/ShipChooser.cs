using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.FuelMarket;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class ShipChooser
{
    public ShipChooser(Route route, decimal activePlasmaCost, decimal gravitonMatterCost)
    {
        Route = route;
        ActivePlasmaCost = activePlasmaCost;
        GravitonMatterCost = gravitonMatterCost;
    }

    private decimal ActivePlasmaCost { get; }
    private decimal GravitonMatterCost { get; }
    private Route Route { get; }

    public ISpaceShip? ChooseShip(ISpaceShip first, ISpaceShip second)
    {
        var launcher = new ShipLauncher(Route);
        var market = new FuelMarket(ActivePlasmaCost, GravitonMatterCost);
        IEnumerable<RouteSegmentResult> firstResults = launcher.LaunchShip(first);
        IEnumerable<RouteSegmentResult> secondResults = launcher.LaunchShip(second);

        RouteSegmentResult[] firstResults1 = firstResults.ToArray();
        if (!firstResults1.All(i => i.Success))
        {
            return secondResults.All(i => i.Success) ? second : null;
        }

        {
            RouteSegmentResult[] secondResults1 = secondResults.ToArray();
            if (!secondResults1.All(i => i.Success))
            {
                return first;
            }

            decimal firstCost = 0, secondCost = 0;
            firstCost += firstResults1.Sum(segmentResult => market.GetCost(segmentResult.FuelTypeConsumed, segmentResult.FuelConsumptionAmount));

            secondCost += secondResults1.Sum(segmentResult => market.GetCost(segmentResult.FuelTypeConsumed, segmentResult.FuelConsumptionAmount));

            return firstCost < secondCost ? first : second;
        }
    }
}