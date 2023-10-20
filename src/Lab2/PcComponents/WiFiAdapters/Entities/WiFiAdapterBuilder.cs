using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.WiFiAdapters.Entities;

public class WiFiAdapterBuilder : IWiFiAdapterBuilder
{
    private int? _wifiVersion;
    private bool? _builtInBluetooth;
    private int? _pciEVersion;
    private int? _powerConsumption;

    public IWiFiAdapterBuilder WithWiFiVersion(int version)
    {
        _wifiVersion = version;
        return this;
    }

    public IWiFiAdapterBuilder WithBuiltInBluetooth(bool bluetooth)
    {
        _builtInBluetooth = bluetooth;
        return this;
    }

    public IWiFiAdapterBuilder WithPciEVersion(int version)
    {
        _pciEVersion = version;
        return this;
    }

    public IWiFiAdapterBuilder WithPowerConsumption(int watts)
    {
        _powerConsumption = watts;
        return this;
    }

    public IWiFiAdapter Build()
    {
        return new WiFiAdapter(
            _wifiVersion ?? throw new ArgumentNullException(nameof(_wifiVersion)),
            _builtInBluetooth ?? throw new ArgumentNullException(nameof(_builtInBluetooth)),
            _pciEVersion ?? throw new ArgumentNullException(nameof(_pciEVersion)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}