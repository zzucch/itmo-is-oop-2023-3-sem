using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Hdds.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.WiFiAdapters.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;

public class Pc : IPc
{
    private readonly ICpuCoolingSystem _cpuCoolingSystem;
    private readonly ICpu _cpu;
    private readonly IGraphicsCard? _graphicsCard;
    private readonly IReadOnlyList<IHdd> _hdds;
    private readonly IMotherboard _motherboard;
    private readonly IPcCase _pcCase;
    private readonly IPsu _psu;
    private readonly IReadOnlyList<IRam> _rams;
    private readonly IReadOnlyList<ISsd> _ssds;
    private readonly IWiFiAdapter? _wifiAdapter;

    internal Pc(
        ICpuCoolingSystem cpuCoolingSystem,
        ICpu cpu,
        IGraphicsCard? graphicsCard,
        IEnumerable<IHdd> hdds,
        IMotherboard motherboard,
        IPcCase pcCase,
        IPsu psu,
        IEnumerable<IRam> rams,
        IEnumerable<ISsd> ssds,
        IWiFiAdapter? wifiAdapter)
    {
        _cpuCoolingSystem = cpuCoolingSystem;
        _cpu = cpu;
        _graphicsCard = graphicsCard;
        _hdds = hdds.ToArray();
        _motherboard = motherboard;
        _pcCase = pcCase;
        _psu = psu;
        _rams = rams.ToArray();
        _ssds = ssds.ToArray();
        _wifiAdapter = wifiAdapter;
    }

    public IPcBuilder Direct(IPcBuilder builder)
    {
        builder
            .WithCpuCooling(_cpuCoolingSystem)
            .WithCpu(_cpu)
            .WithMotherboard(_motherboard)
            .WithPcCase(_pcCase)
            .WithPsu(_psu);

        if (_graphicsCard is not null)
        {
            builder.WithGraphicsCard(_graphicsCard);
        }

        if (_wifiAdapter is not null)
        {
            builder.WithWiFiAdapter(_wifiAdapter);
        }

        foreach (IHdd hdd in _hdds)
        {
            builder.AddHdd(hdd);
        }

        foreach (IRam ram in _rams)
        {
            builder.AddRam(ram);
        }

        foreach (ISsd ssd in _ssds)
        {
            builder.AddSsd(ssd);
        }

        return builder;
    }

    public bool IsSingleOrNoneWiFiModule()
    {
        return (_wifiAdapter is not null && _motherboard.WiFiModule) is false;
    }

    public bool IsAtLeastOneDiskDrivePresent()
    {
        return _hdds.Count > 0 || _ssds.Count > 0;
    }

    public bool IsCpuWithGpuOrPcWithGraphicsCard()
    {
        return _cpu.IntegratedGraphicsProcessor || _graphicsCard is not null;
    }

    public bool IsRamXmpSupportedOrNoXmp()
    {
        foreach (IRam ram in _rams)
        {
            if (ram.Xmps.Count <= 0)
            {
                continue;
            }

            if (_motherboard.Chipset.SupportsXmp is false)
            {
                return false;
            }

            bool any = ram.Xmps.Where(
                xmp => _cpu.SupportedMemoryFrequencies.Any(
                    i => i == xmp.Frequency)).Any(
                xmp => _motherboard.Chipset.SupportedRamFrequencies.Any(
                    i => i == xmp.Frequency));

            if (any is false)
            {
                return false;
            }
        }

        return true;
    }

    public bool IsBiosAndCpuCompatible()
    {
        return _motherboard.Bios.IsCompatibleWithCpu(_cpu);
    }

    public bool IsCpuAndRamProfileCompatible()
    {
        return _rams.Any(ram => ram.JedecProfiles.Any(
            profile => _cpu.SupportedMemoryFrequencies.Any(
                i => i == profile.Frequency)));
    }

    public bool IsMotherboardAndRamProfileCompatible()
    {
        return _rams.Any(ram => ram.JedecProfiles.Any(
            profile => _motherboard.Chipset.SupportedRamFrequencies.Any(
                i => i == profile.Frequency)));
    }

    public bool IsMotherboardAndRamXmpCompatible()
    {
        foreach (IRam ram in _rams)
        {
            if (ram.Xmps.Count <= 0)
            {
                continue;
            }

            if (_motherboard.Chipset.SupportsXmp is false)
            {
                return false;
            }

            if (ram.Xmps.Any(xmp => _motherboard.Chipset.SupportedRamFrequencies.Any(i => i == xmp.Frequency)) is false)
            {
                return false;
            }
        }

        return true;
    }

    public bool IsMotherboardAndCpuSocketCompatible()
    {
        return _motherboard.IsCompatibleWithSocket(_cpu.Socket);
    }

    public bool IsMotherboardAndRamDdrVersionCompatible()
    {
        return _rams.All(ram => _motherboard.IsCompatibleWithDdrVersion(ram.DdrVersion));
    }

    public bool IsCpuCoolingSystemAndCpuSocketCompatible()
    {
        return _cpuCoolingSystem.IsCompatibleWithCpuSocket(_cpu.Socket);
    }

    public bool IsCpuCoolingSystemTdpAndCpuTdpCompatible()
    {
        return _cpuCoolingSystem.IsCompatibleWithCpuTdp(_cpu.Tdp);
    }

    public bool IsMotherboardPciEAmountEnough()
    {
        int pciECount = 0;

        if (_graphicsCard is not null)
        {
            pciECount++;
        }

        if (_wifiAdapter is not null)
        {
            pciECount++;
        }

        pciECount += _ssds.Count(ssd => ssd.ConnectionInterface is SsdConnectionInterface.PciE);

        return _motherboard.PciEAmount.Amount >= pciECount;
    }

    public bool IsMotherboardSataAmountEnough()
    {
        int sataCount = 0;

        sataCount += _hdds.Count;
        sataCount += _ssds.Count(ssd => ssd.ConnectionInterface is SsdConnectionInterface.Sata);

        return _motherboard.SataAmount.Amount >= sataCount;
    }

    public bool IsMotherboardRamSocketsAmountEnough()
    {
        return _rams.Count <= _motherboard.RamSocketAmount.Amount;
    }

    public bool IsGraphicsCardSizeAndPcCaseCompatible()
    {
        if (_graphicsCard is null)
        {
            return true;
        }

        return _pcCase.Dimensions.GraphicsCardMaxHeight >= _graphicsCard.Dimensions.Height
               && _pcCase.Dimensions.Length >= _graphicsCard.Dimensions.Length
               && _pcCase.Dimensions.Width >= _graphicsCard.Dimensions.Width;
    }

    public bool IsCpuCoolingSystemSizeAndPcCaseCompatible()
    {
        return _pcCase.Dimensions.MaxCpuCoolingSystemUnitHeight >= _cpuCoolingSystem.Dimensions.Height
               && _pcCase.Dimensions.MaxCpuCoolingSystemUnitLength >= _cpuCoolingSystem.Dimensions.Length
               && _pcCase.Dimensions.MaxCpuCoolingSystemUnitWidth >= _cpuCoolingSystem.Dimensions.Width;
    }

    public bool IsMotherboardFormFactorAndPcCaseCompatible()
    {
        return _pcCase.IsCompatibleWithMotherboardFormFactor(_motherboard.FormFactor);
    }

    public bool IsPsuPowerEnough()
    {
        return _psu.IsPowerEnough(GetAllPowerConsumption());
    }

    public bool IsRecommendedPsuPower()
    {
        return _psu.IsPowerRecommended(GetAllPowerConsumption());
    }

    private PowerConsumption GetAllPowerConsumption()
    {
        decimal powerConsumption = decimal.Zero;

        powerConsumption += _cpu.PowerConsumption.PowerConsumed;

        if (_graphicsCard != null)
        {
            powerConsumption += _graphicsCard.PowerConsumption.PowerConsumed;
        }

        if (_wifiAdapter != null)
        {
            powerConsumption += _wifiAdapter.PowerConsumption.PowerConsumed;
        }

        powerConsumption += _hdds.Sum(hdd => hdd.PowerConsumption.PowerConsumed);
        powerConsumption += _ssds.Sum(ssd => ssd.PowerConsumption.PowerConsumed);
        powerConsumption += decimal.ToInt32(decimal.Ceiling(_rams.Sum(ram => ram.PowerConsumption.PowerConsumed)));

        return new PowerConsumption(powerConsumption);
    }
}