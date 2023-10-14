using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public record RouteSegmentResult(
    bool Success,
    Fuel FuelTypeConsumed,
    double FuelConsumptionAmount,
    TimeSpan TimeTaken,
    bool ShipLost,
    bool CrewLost,
    bool ShipDestroyed,
    bool DeflectorDestroyed);