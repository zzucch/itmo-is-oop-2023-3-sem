using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;

public class Motherboard : IMotherboard
{
    private readonly string _cpuSocket;
    private readonly Chipset _chipset;
    private readonly int _ddrVersion;

    internal Motherboard(
        string cpuSocket,
        int pciEAmount,
        int sataAmount,
        Chipset chipset,
        int ddrVersion,
        int ramSocketAmount,
        string formFactor,
        bool wiFiModule,
        IBios bios)
    {
        _cpuSocket = cpuSocket;
        PciEAmount = pciEAmount;
        SataAmount = sataAmount;
        _chipset = chipset;
        _ddrVersion = ddrVersion;
        RamSocketAmount = ramSocketAmount;
        FormFactor = formFactor;
        WiFiModule = wiFiModule;
        Bios = bios;
    }

    public IBios Bios { get; }
    public int SataAmount { get; }
    public int PciEAmount { get; }
    public bool WiFiModule { get; }
    public string FormFactor { get; }
    public int RamSocketAmount { get; }

    public bool IsCompatibleWithSocket(string socket)
    {
        return socket == _cpuSocket;
    }

    public bool IsCompatibleWithDdrVersion(int ddrVersion)
    {
        return ddrVersion == _ddrVersion;
    }

    public IMotherboardBuilder Direct(IMotherboardBuilder builder)
    {
        builder
            .WithCpuSocket(_cpuSocket)
            .WithPciEAmount(PciEAmount)
            .WithSataAmount(SataAmount)
            .WithChipset(_chipset)
            .WithDdrVersion(_ddrVersion)
            .WithRamSocketAmount(RamSocketAmount)
            .WithFormFactor(FormFactor)
            .WithWiFiModule(WiFiModule)
            .WithBios(Bios);

        return builder;
    }
}