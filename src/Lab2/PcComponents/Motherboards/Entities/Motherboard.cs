using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;

public class Motherboard : IMotherboard
{
    private readonly string _cpuSocket;
    private readonly int _pciEAmount;
    private readonly int _sataAmount;
    private readonly Chipset _chipset;
    private readonly int _ddrVersion;
    private readonly int _ramSocketAmount;
    private readonly string _formFactor;
    private readonly IBios _bios;

    internal Motherboard(
        string cpuSocket,
        int pciEAmount,
        int sataAmount,
        Chipset chipset,
        int ddrVersion,
        int ramSocketAmount,
        string formFactor,
        IBios bios)
    {
        _cpuSocket = cpuSocket;
        _pciEAmount = pciEAmount;
        _sataAmount = sataAmount;
        _chipset = chipset;
        _ddrVersion = ddrVersion;
        _ramSocketAmount = ramSocketAmount;
        _formFactor = formFactor;
        _bios = bios;
    }

    public IMotherboardBuilder Direct(IMotherboardBuilder builder)
    {
        builder
            .WithCpuSocket(_cpuSocket)
            .WithPciEAmount(_pciEAmount)
            .WithSataAmount(_sataAmount)
            .WithChipset(_chipset)
            .WithDdrVersion(_ddrVersion)
            .WithRamSocketAmount(_ramSocketAmount)
            .WithFormFactor(_formFactor)
            .WithBios(_bios);

        return builder;
    }
}