using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;

public class Message : IRenderable
{
    private readonly IRenderable _name;
    private readonly IRenderable _body;
    private readonly MessagePriorityLevel _priorityLevel;

    public Message(IRenderable name, IRenderable body, MessagePriorityLevel priorityLevel)
    {
        _name = name;
        _body = body;
        _priorityLevel = priorityLevel;
    }

    public string Render()
    {
        var builder = new StringBuilder();

        builder.Append(_name.Render());
        builder.Append('\n');
        builder.Append(_body.Render());
        builder.Append('\n');

        return builder.ToString();
    }

    public bool IsAuthorizedToPassPriorityLevel(MessagePriorityLevel priorityLevel)
    {
        return _priorityLevel.Level >= priorityLevel.Level;
    }
}