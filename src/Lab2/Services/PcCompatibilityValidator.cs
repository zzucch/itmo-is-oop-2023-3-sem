using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.PcCompatibilityChecks;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class PcCompatibilityValidator
{
    private readonly IPc _pc;
    private readonly IReadOnlyList<IPcCompatibilityChecker> _checkers;

    public PcCompatibilityValidator(
        IPc pc,
        IEnumerable<IPcCompatibilityChecker> compatibilityCheckers)
    {
        _pc = pc;
        _checkers = compatibilityCheckers.ToArray();
    }

    public BuildResult Validate()
    {
        bool success = true;
        var comments = new List<string>();
        bool warrantyDisclaimer = false;

        foreach (IPcCompatibilityChecker checker in _checkers)
        {
            PcCompatibilityCheckResult compatibilityCheckResult = checker.CheckCompatibility(_pc);

            switch (compatibilityCheckResult)
            {
                case PcCompatibilityCheckResult.Success:
                    break;
                case PcCompatibilityCheckResult.WarrantyDisclaimed warrantyDisclaimed:
                    warrantyDisclaimer = true;
                    comments.Add(warrantyDisclaimed.Comment);
                    break;
                case PcCompatibilityCheckResult.Failure failure:
                    success = false;
                    comments.Add(failure.Comment);
                    warrantyDisclaimer = true;
                    break;
            }
        }

        return new BuildResult(
            Success: success,
            Comments: new ReadOnlyCollection<string>(comments),
            WarrantyDisclaimer: warrantyDisclaimer);
    }
}