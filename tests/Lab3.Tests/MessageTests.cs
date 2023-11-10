using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Renderables;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Models;
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
        var topic = new Topic(new TopicName("topic-name"), user);

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
        var topic = new Topic(new TopicName("topic-name"), user);

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
            new MessagePriorityLevel(1));
        var topic = new Topic(new TopicName("topic-name"), user);

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
        IUser userMock = Substitute.For<IUser>();
        var message = new Message(
            new Text("message-name"),
            new Text("message-body"),
            new MessagePriorityLevel(1));

        var proxy = new MessagePriorityLevelAuthProxy(userMock, new MessagePriorityLevel(50));

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
            new MessagePriorityLevel(1));
        ILogger loggerMock = Substitute.For<ILogger>();

        var decorator = new LoggingRecipientDecorator(user, loggerMock);

        var topic = new Topic(new TopicName("topic-name"), decorator);

        // Act
        topic.ForwardMessage(message);

        // Assert
        loggerMock.Received().LogInformation(Arg.Any<string>());
    }

    [Fact]
    public void ReceiveMessage_Should()
    {
        // Arrange
        IMessenger messengerMock = Substitute.For<IMessenger>();
        var message = new Message(
            new Text("message-name"),
            new Text("message-body"),
            new MessagePriorityLevel(1));

        var topic = new Topic(new TopicName("topic-name"), messengerMock);

        // Act
        topic.ForwardMessage(message);

        // Assert
        messengerMock.Received().ReceiveMessage(Arg.Any<Message>());
    }
}