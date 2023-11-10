using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class LoggingRecipientDecorator : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly ILogger _logger;

    public LoggingRecipientDecorator(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void ReceiveMessage(IMessage message)
    {
        _logger.LogInformation(MessageToLogInformation(message));

        _recipient.ReceiveMessage(message);
    }

    private static string MessageToLogInformation(IRenderable message)
    {
        return $"Received message: {message.Render()}";
    }
}