using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;

public record Chipset(IReadOnlyCollection<RamFrequency> SupportedRamFrequencies, bool SupportsXmp);