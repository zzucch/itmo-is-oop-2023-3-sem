using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;

public record Chipset(IReadOnlyCollection<int> SupportedRamSpeeds, bool SupportsXmp);