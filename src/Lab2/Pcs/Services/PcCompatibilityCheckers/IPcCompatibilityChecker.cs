using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

public interface IPcCompatibilityChecker
{
    CompatibilityCheckResult CheckCompatibility(PcValidationModel pc);
}