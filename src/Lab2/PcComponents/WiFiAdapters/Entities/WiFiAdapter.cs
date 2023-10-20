namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.WiFiAdapters.Entities;

public class WiFiAdapter : IWiFiAdapter
{
    private readonly int _wifiVersion;
    private readonly bool _builtInBluetooth;
    private readonly int _pciEVersion;
    private readonly int _powerConsumption;

    internal WiFiAdapter(
        int wifiVersion,
        bool builtInBluetooth,
        int pciEVersion,
        int powerConsumption)
    {
        _wifiVersion = wifiVersion;
        _builtInBluetooth = builtInBluetooth;
        _pciEVersion = pciEVersion;
        _powerConsumption = powerConsumption;
    }

    public IWiFiAdapterBuilder Direct(IWiFiAdapterBuilder builder)
    {
        builder
            .WithWiFiVersion(_wifiVersion)
            .WithBuiltInBluetooth(_builtInBluetooth)
            .WithPciEVersion(_pciEVersion)
            .WithPowerConsumption(_powerConsumption);

        return builder;
    }
}