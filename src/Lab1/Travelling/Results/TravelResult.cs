using System;
using Itmo.ObjectOrientedProgramming.Lab1.FuelMarket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Travelling.Results;

public record TravelResult(
    bool Success,
    TimeSpan TravelTimeTaken,
    Fuel FuelConsumed,
    bool ShipLost);