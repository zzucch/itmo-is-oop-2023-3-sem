using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sales.Entities.CostStrategies;

public interface IFuelCostStrategy
{
    decimal GetCost(Fuel fuel);
}