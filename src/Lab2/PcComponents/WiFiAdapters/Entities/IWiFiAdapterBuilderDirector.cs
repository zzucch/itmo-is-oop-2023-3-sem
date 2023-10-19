namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.WiFiAdapters.Entities;

public interface IWiFiAdapterBuilderDirector
{
    IWiFiAdapterBuilder Direct(IWiFiAdapterBuilder adapterBuilder);
}