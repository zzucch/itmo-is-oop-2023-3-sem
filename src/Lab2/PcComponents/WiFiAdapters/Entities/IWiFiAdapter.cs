namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.WiFiAdapters.Entities;

public interface IWiFiAdapter : IWiFiAdapterBuilderDirector
{
    public int PowerConsumption { get; }
}