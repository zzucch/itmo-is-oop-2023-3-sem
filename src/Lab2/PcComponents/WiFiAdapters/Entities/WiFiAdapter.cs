using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.WiFiAdapters.Entities;

public class WiFiAdapter : IWiFiAdapter
{
    private readonly int _wifiVersion;
    private readonly bool _builtInBluetooth;
    private readonly int _pciEVersion;

    internal WiFiAdapter(
        int wifiVersion,
        bool builtInBluetooth,
        int pciEVersion,
        PowerConsumption powerConsumption,
        PcComponentName name)
    {
        _wifiVersion = wifiVersion;
        _builtInBluetooth = builtInBluetooth;
        _pciEVersion = pciEVersion;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public PcComponentName Name { get; }
    public PowerConsumption PowerConsumption { get; }

    public IWiFiAdapterBuilder Direct(IWiFiAdapterBuilder builder)
    {
        builder
            .WithWiFiVersion(_wifiVersion)
            .WithBuiltInBluetooth(_builtInBluetooth)
            .WithPciEVersion(_pciEVersion)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}