using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entities;

public interface IGraphicsCard : IGraphicsCardBuilderDirector
{
    public int PowerConsumption { get; }
    public GraphicsCardDimensions Dimensions { get; }
}