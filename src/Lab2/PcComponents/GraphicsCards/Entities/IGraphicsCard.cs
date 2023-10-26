using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entities;

public interface IGraphicsCard : IGraphicsCardBuilderDirector
{
    public PowerConsumption PowerConsumption { get; }
    public GraphicsCardDimensions Dimensions { get; }
}