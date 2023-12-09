using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Hdds.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.WiFiAdapters.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

public record PcValidationModel(
    ICpuCoolingSystem CpuCoolingSystem,
    ICpu Cpu,
    IGraphicsCard? GraphicsCard,
    IReadOnlyList<IHdd> Hdds,
    IMotherboard Motherboard,
    IPcCase PcCase,
    IPsu Psu,
    IReadOnlyList<IRam> Rams,
    IReadOnlyList<ISsd> Ssds,
    IWiFiAdapter? WiFiAdapter);