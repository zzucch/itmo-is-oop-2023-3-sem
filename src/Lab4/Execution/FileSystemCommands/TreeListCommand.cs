using Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemProviders;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.FileSystemCommands;

public class TreeListCommand : IFileSystemCommand
{
    private readonly TreeListContext _context;
    private readonly IVisitor _visitor;

    public TreeListCommand(TreeListContext context, IVisitor visitor)
    {
        _context = context;
        _visitor = visitor;
    }

    public void Execute(FileSystemProvider fileSystemProvider)
    {
        switch (fileSystemProvider.GetDirectories(_context.Depth))
        {
            case FileSystemSubtreeResult.Success success:
                _context.DisplayDriver.Write(_visitor.Visit(success.TreeElements));
                break;
            case FileSystemSubtreeResult.Failure failure:
                _context.DisplayDriver.Write(failure.Message);
                break;
        }
    }
}