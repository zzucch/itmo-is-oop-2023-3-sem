using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

public record BuildResult(bool Success, ReadOnlyCollection<string> Comments, bool WarrantyDisclaimer);