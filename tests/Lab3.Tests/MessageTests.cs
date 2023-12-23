using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Renderables;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageTests
{
    [Fact]
    public void ReceiveMessage_ShouldSaveMessageAsUnread_WhenUserReceivesMessage()
    {
        // Arrange
        IUser user = new User();
        var message = new Message(
            new Text("message-name"),
            new Text("message-body"),
            new MessagePriorityLevel(0));
        var topic = new Topic(new TopicName("topic-name"), new UserRecipient(user));

        // Act
        topic.ForwardMessage(message);

        // Assert
        Assert.Equal(
            expected: new UserMessageStatus.Unread(),
            actual: user.FindMessageStatus(message));
    }

    [Fact]
    public void MarkMessageAsRead_ShouldMarkMessageAsRead_WhenMessageIsUnread()
    {
        // Arrange
        IUser user = new User();
        var message = new Message(
            new Text("message-name"),
            new Text("message-body"),
            new MessagePriorityLevel(0));
        var topic = new Topic(new TopicName("topic-name"), new UserRecipient(user));

        // Act
        topic.ForwardMessage(message);
        user.MarkMessageAsRead(message);

        // Assert
        Assert.Equal(
            expected: new UserMessageStatus.Read(),
            actual: user.FindMessageStatus(message));
    }

    [Fact]
    public void MarkMessageAsRead_ShouldThrow_WhenMessageIsRead()
    {
        // Arrange
        IUser user = new User();
        var message = new Message(
            new Text("message-name"),
            new Text("message-body"),
            new MessagePriorityLevel(0));
        var topic = new Topic(new TopicName("topic-name"), new UserRecipient(user));

        // Act
        topic.ForwardMessage(message);
        user.MarkMessageAsRead(message);
        MarkMessageAsReadResult result = user.MarkMessageAsRead(message);

        // Assert
        Assert.Equal(
            expected: new MarkMessageAsReadResult.Failure(),
            actual: result);
    }

    [Fact]
    public void ForwardMessage_ShouldNotForwardMessageToUser_WhenIncompatiblePriorityLevel()
    {
        // Arrange
        const int lowPriority = 1;
        const int highPriority = 50;

        IUser userMock = Substitute.For<IUser>();
        var message = new Message(
            new Text("message-name"),
            new Text("message-body"),
            new MessagePriorityLevel(lowPriority));

        var proxy = new MessagePriorityLevelAuthProxy(
            new UserRecipient(userMock),
            new MessagePriorityLevel(highPriority));

        var topic = new Topic(new TopicName("topic-name"), proxy);

        // Act
        topic.ForwardMessage(message);

        // Assert
        userMock.DidNotReceive().ReceiveMessage(Arg.Any<Message>());
    }

    [Fact]
    public void ForwardMessage_ShouldLogForwardedMessage_WhenLoggingIsEnabled()
    {
        // Arrange
        IUser user = new User();
        var message = new Message(
            new Text("message-name"),
            new Text("message-body"),
            new MessagePriorityLevel(0));
        ILogger loggerMock = Substitute.For<ILogger>();

        var decorator = new LoggingRecipientDecorator(new UserRecipient(user), loggerMock);

        var topic = new Topic(new TopicName("topic-name"), decorator);

        // Act
        topic.ForwardMessage(message);

        // Assert
        loggerMock.Received().LogInformation(Arg.Any<string>());
    }

    [Fact]
    public void ForwardMessage_ShouldDisplayInformation_WhenMessageForwardedToMessenger()
    {
        // Arrange
        IMessenger messengerMock = Substitute.For<IMessenger>();
        var message = new Message(
            new Text("message-name"),
            new Text("message-body"),
            new MessagePriorityLevel(0));

        var topic = new Topic(new TopicName("topic-name"), new MessengerRecipient(messengerMock));

        // Act
        topic.ForwardMessage(message);

        // Assert
        messengerMock.Received().DisplayInformation(Arg.Any<string>());
    }
}