using System.Collections.Generic;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.Parameters;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Visitors;

public class Visitor : IVisitor
{
    private readonly TreeListParameters _parameters;

    public Visitor(TreeListParameters parameters)
    {
        _parameters = parameters;
    }

    public string Visit(IEnumerable<TreeElement> treeElements)
    {
        var builder = new StringBuilder();

        foreach (TreeElement element in treeElements)
        {
            switch (element)
            {
                case TreeElement.File file:
                    builder.Append(new string(_parameters.Indentation, file.Depth) +
                                   _parameters.FileIcon +
                                   file.Name);
                    break;
                case TreeElement.Directory directory:
                    builder.Append(new string(_parameters.Indentation, directory.Depth) +
                                   _parameters.DirectoryIcon +
                                   directory.Name);
                    break;
            }
        }

        return builder.ToString();
    }
}