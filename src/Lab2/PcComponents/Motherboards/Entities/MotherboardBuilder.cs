using System;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;

public class MotherboardBuilder : IMotherboardBuilder
{
    private PcComponentName? _name;
    private CpuSocket? _cpuSocket;
    private MotherboardPciEAmount? _pciEAmount;
    private MotherboardSataAmount? _sataAmount;
    private Chipset? _chipset;
    private RamDdrVersion? _ddrVersion;
    private MotherboardRamAmount? _ramSocketAmount;
    private MotherboardFormFactor? _formFactor;
    private bool? _wifiModule;
    private IBios? _bios;

    public IMotherboardBuilder WithName(PcComponentName name)
    {
        _name = name;
        return this;
    }

    public IMotherboardBuilder WithCpuSocket(CpuSocket socket)
    {
        _cpuSocket = socket;
        return this;
    }

    public IMotherboardBuilder WithPciEAmount(MotherboardPciEAmount amount)
    {
        _pciEAmount = amount;
        return this;
    }

    public IMotherboardBuilder WithSataAmount(MotherboardSataAmount amount)
    {
        _sataAmount = amount;
        return this;
    }

    public IMotherboardBuilder WithChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherboardBuilder WithDdrVersion(RamDdrVersion version)
    {
        _ddrVersion = version;
        return this;
    }

    public IMotherboardBuilder WithRamSocketAmount(MotherboardRamAmount amount)
    {
        _ramSocketAmount = amount;
        return this;
    }

    public IMotherboardBuilder WithFormFactor(MotherboardFormFactor formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder WithWiFiModule(bool wifi)
    {
        _wifiModule = wifi;
        return this;
    }

    public IMotherboardBuilder WithBios(IBios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherboard Build()
    {
        return new Motherboard(
            _cpuSocket ?? throw new ArgumentNullException(nameof(_cpuSocket)),
            _pciEAmount ?? throw new ArgumentNullException(nameof(_pciEAmount)),
            _sataAmount ?? throw new ArgumentNullException(nameof(_sataAmount)),
            _chipset ?? throw new ArgumentNullException(nameof(_chipset)),
            _ddrVersion ?? throw new ArgumentNullException(nameof(_ddrVersion)),
            _ramSocketAmount ?? throw new ArgumentNullException(nameof(_ramSocketAmount)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _wifiModule ?? throw new ArgumentNullException(nameof(_wifiModule)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}