using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sales.Entities.CostStrategies;

public class ActivePlasmaCostStrategy : IFuelCostStrategy
{
    private readonly decimal _activePlasmaCost;

    public ActivePlasmaCostStrategy(decimal activePlasmaCost)
    {
        _activePlasmaCost = activePlasmaCost;
    }

    public decimal GetCost(Fuel fuel)
    {
        return _activePlasmaCost * (decimal)fuel.Amount;
    }
}