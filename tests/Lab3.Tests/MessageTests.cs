using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Renderables;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;
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
        IMessage message = new Message(
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
        IMessage message = new Message(
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
        IMessage message = new Message(
            new Text("message-name"),
            new Text("message-body"),
            new MessagePriorityLevel(1));
        var topic = new Topic(new TopicName("topic-name"), user);

        // Act
        topic.ForwardMessage(message);
        user.MarkMessageAsRead(message);

        // Assert
        Assert.Throws<InvalidOperationException>(() => user.MarkMessageAsRead(message));
    }

    [Fact]
    public void ForwardMessage_ShouldNot_()
    {
        // Arrange
        IUser userMock = Substitute.For<IUser>();
        IMessage message = new Message(
            new Text("message-name"),
            new Text("message-body"),
            new MessagePriorityLevel(1));

        var proxy = new RecipientAuthorizationByMessagePriorityLevelProxy(userMock, new MessagePriorityLevel(50));

        var topic = new Topic(new TopicName("topic-name"), proxy);

        // Act
        topic.ForwardMessage(message);

        // Assert
        userMock.DidNotReceive().ReceiveMessage(Arg.Any<IMessage>());
    }
}