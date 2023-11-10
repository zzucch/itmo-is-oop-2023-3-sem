using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.Displays.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.Displays.Entities;

public interface IDisplay : IRecipient
{
    DisplayMessageResult TryDisplayMessage();
}