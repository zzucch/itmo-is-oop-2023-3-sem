using System;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

public record RouteSegmentResult(
    bool Success,
    Fuel FuelConsumed,
    TimeSpan TimeTaken,
    bool ShipLost,
    bool CrewLost,
    bool ShipDestroyed,
    bool DeflectorDestroyed);