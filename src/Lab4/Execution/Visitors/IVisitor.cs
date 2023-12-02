using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Visitors;

public interface IVisitor
{
    string Visit(IEnumerable<TreeElement> treeElements);
}