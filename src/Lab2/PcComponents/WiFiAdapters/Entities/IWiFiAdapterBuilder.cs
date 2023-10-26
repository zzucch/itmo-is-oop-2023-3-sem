using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.WiFiAdapters.Entities;

public interface IWiFiAdapterBuilder
{
    IWiFiAdapterBuilder WithWiFiVersion(int version);
    IWiFiAdapterBuilder WithBuiltInBluetooth(bool bluetooth);
    IWiFiAdapterBuilder WithPciEVersion(int version);
    IWiFiAdapterBuilder WithPowerConsumption(PowerConsumption powerConsumption);
    IWiFiAdapter Build();
}