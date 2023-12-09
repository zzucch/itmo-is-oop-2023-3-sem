using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sales.Entities.Markets;

public interface IFuelMarket
{
    public decimal GetCost(Fuel fuel);
}