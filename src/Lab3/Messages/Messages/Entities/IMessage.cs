using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Entities;

public interface IMessage : IRenderable
{
    bool IsAuthorizedToPassPriorityLevel(MessagePriorityLevel priorityLevel);
}