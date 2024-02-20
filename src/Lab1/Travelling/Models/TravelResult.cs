using System;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Travelling.Models;

public record TravelResult(
    bool Success,
    TimeSpan TravelTimeTaken,
    Fuel FuelConsumed,
    bool ShipLost);