using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;

public interface IBiosBuilder
{
    IBiosBuilder WithType(BiosType type);
    IBiosBuilder WithVersion(BiosVersion version);
    IBiosBuilder AddSupportedCpu(ICpu cpu);
    IBios Build();
}