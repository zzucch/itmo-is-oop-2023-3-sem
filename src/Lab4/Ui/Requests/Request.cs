using Itmo.ObjectOrientedProgramming.Lab4.Execution.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;

public record Request(IIterator<string> Value, ICommandContextBuilder CommandContextBuilder);