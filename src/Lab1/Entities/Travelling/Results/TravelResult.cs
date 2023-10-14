using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling.Results;

public record TravelResult(
    bool Success,
    double TravelTimeTaken,
    Fuel FuelTypeConsumed,
    double TravelFuelConsumption,
    bool ShipLost);