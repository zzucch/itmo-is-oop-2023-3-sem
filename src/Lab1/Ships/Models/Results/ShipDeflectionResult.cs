using Itmo.ObjectOrientedProgramming.Lab1.Damage.Entities.Deflection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Results;

public record ShipDeflectionResult(
    DeflectionResult? DeflectorResult,
    DeflectionResult? HullResult);