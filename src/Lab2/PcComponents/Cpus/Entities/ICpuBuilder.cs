namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

public interface ICpuBuilder
{
    ICpuBuilder WithCoreSpeed(int mHz);
    ICpuBuilder WithCoreAmount(int cores);
    ICpuBuilder WithSocket(string socket);
    ICpuBuilder WithIntegratedGraphicsProcessor(bool igp);
    ICpuBuilder AddSupportedMemoryFrequency(int speed);
    ICpuBuilder WithTdp(int tdp);
    ICpuBuilder WithPowerConsumption(int watts);
    ICpu Build();
}