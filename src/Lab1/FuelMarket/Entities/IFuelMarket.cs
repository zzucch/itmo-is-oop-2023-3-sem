using Itmo.ObjectOrientedProgramming.Lab1.FuelMarket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.FuelMarket.Entities;

public interface IFuelMarket
{
    public decimal GetCost(Fuel fuel);
}