using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Hdds.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.WiFiAdapters.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Services.PcCompatibilityCheckers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;

public class PcBuilder : IPcBuilder
{
    private readonly List<IHdd> _hdds = new();
    private readonly List<IRam> _rams = new();
    private readonly List<ISsd> _ssds = new();
    private List<IPcCompatibilityChecker> _checkers = new();
    private ICpuCoolingSystem? _cpuCoolingSystem;
    private ICpu? _cpu;
    private IGraphicsCard? _graphicsCard;
    private IMotherboard? _motherboard;
    private IPcCase? _pcCase;
    private IPsu? _psu;
    private IWiFiAdapter? _wifiAdapter;

    public IPcBuilder WithCpuCooling(ICpuCoolingSystem cpuCoolingSystem)
    {
        _cpuCoolingSystem = cpuCoolingSystem;
        return this;
    }

    public IPcBuilder WithCpu(ICpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IPcBuilder WithGraphicsCard(IGraphicsCard graphicsCard)
    {
        _graphicsCard = graphicsCard;
        return this;
    }

    public IPcBuilder AddHdd(IHdd hdd)
    {
        _hdds.Add(hdd);
        return this;
    }

    public IPcBuilder WithMotherboard(IMotherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IPcBuilder WithPcCase(IPcCase pcCase)
    {
        _pcCase = pcCase;
        return this;
    }

    public IPcBuilder WithPsu(IPsu psu)
    {
        _psu = psu;
        return this;
    }

    public IPcBuilder AddRam(IRam ram)
    {
        _rams.Add(ram);

        return this;
    }

    public IPcBuilder AddSsd(ISsd ssd)
    {
        _ssds.Add(ssd);

        return this;
    }

    public IPcBuilder WithWiFiAdapter(IWiFiAdapter wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public IPcBuilder WithPcCompatibilityCheckers(IEnumerable<IPcCompatibilityChecker> compatibilityCheckers)
    {
        _checkers = compatibilityCheckers.ToList();
        return this;
    }

    public PcBuildResult Build()
    {
        if (_rams.Count is 0)
        {
            throw new ArgumentException(message: "PC must have RAM");
        }

        if (_hdds.Count is 0 && _ssds.Count is 0)
        {
            throw new ArgumentException(message: "PC must have at least one disk drive (HDD or SSD)");
        }

        var invalidPc = new PcValidationModel(
            _cpuCoolingSystem ?? throw new ArgumentNullException(nameof(_cpuCoolingSystem)),
            _cpu ?? throw new ArgumentNullException(nameof(_cpu)),
            _graphicsCard,
            _hdds,
            _motherboard ?? throw new ArgumentNullException(nameof(_motherboard)),
            _pcCase ?? throw new ArgumentNullException(nameof(_pcCase)),
            _psu ?? throw new ArgumentNullException(nameof(_psu)),
            _rams,
            _ssds,
            _wifiAdapter);

        return Validate(invalidPc);
    }

    private PcBuildResult Validate(PcValidationModel pcValidationModel)
    {
        bool success = true;
        var comments = new List<string>();
        bool warrantyDisclaimer = false;

        foreach (CompatibilityCheckResult compatibilityCheckResult in _checkers.Select(checker => checker.CheckCompatibility(pcValidationModel)))
        {
            switch (compatibilityCheckResult)
            {
                case CompatibilityCheckResult.Success:
                    break;
                case CompatibilityCheckResult.WarrantyDisclaimed warrantyDisclaimed:
                    warrantyDisclaimer = true;
                    comments.Add(warrantyDisclaimed.Comment);
                    break;
                case CompatibilityCheckResult.Failure failure:
                    success = false;
                    comments.Add(failure.Comment);
                    warrantyDisclaimer = true;
                    break;
            }
        }

        if (success is false)
        {
            return new PcBuildResult.Failure(comments);
        }

        var validPc = new Pc(
            pcValidationModel.CpuCoolingSystem,
            pcValidationModel.Cpu,
            pcValidationModel.GraphicsCard,
            pcValidationModel.Hdds,
            pcValidationModel.Motherboard,
            pcValidationModel.PcCase,
            pcValidationModel.Psu,
            pcValidationModel.Rams,
            pcValidationModel.Ssds,
            pcValidationModel.WiFiAdapter);

        if (warrantyDisclaimer)
        {
            return new PcBuildResult.WarrantyDisclaimed(validPc, comments);
        }

        return new PcBuildResult.Success(validPc);
    }
}