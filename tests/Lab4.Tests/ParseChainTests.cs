using Itmo.ObjectOrientedProgramming.Lab4.Execution.CommandContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.FileSystemDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Disconnect;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Parameters;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Parameters.Flags;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Parameters.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests.Iterators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParseChainTests
{
    [Fact]
    public void Handle_ShouldParseRequestProperly_WhenCorrectConnectRequestPassed()
    {
        // Arrange
        IParseChainLink parseChain = GetParseChain();
        const string command = "connect /home/pc/RiderProjects -m local";
        var request = new Request(
            new RequestStringIterator(command.Split()),
            new CommandContextBuilder());

        // Act
        ParseResult result = parseChain.Handle(request);

        // Assert
        Assert.True(result is ParseResult.Success);
        if (result is not ParseResult.Success success) return;
        Assert.True(success.CommandContext.Command is ConnectCommand);
        Assert.NotNull(success.CommandContext.Path);
        Assert.Equal(expected: "/home/pc/RiderProjects", actual: success.CommandContext.Path.Value);
        Assert.True(success.CommandContext.FileSystemDriver is LocalFileSystemDriver);
    }

    [Fact]
    public void Handle_ShouldParseRequestProperly_WhenCorrectFileShowRequestPassed()
    {
        // Arrange
        IParseChainLink parseChain = GetParseChain();
        const string command = "file show /home/pc/RiderProjects/zzucch/src/Lab4/Ui/Parsers/Parameters/DepthChainLink.cs -m console";
        var request = new Request(
            new RequestStringIterator(command.Split()),
            new CommandContextBuilder());

        request.CommandContextBuilder.WithFileSystemDriver(new LocalFileSystemDriver());

        // Act
        ParseResult result = parseChain.Handle(request);

        // Assert
        Assert.True(result is ParseResult.Success);
        if (result is not ParseResult.Success success) return;
        Assert.True(success.CommandContext.Command is FileShowCommand);
        Assert.NotNull(success.CommandContext.Path);
        Assert.Equal(
            expected: "/home/pc/RiderProjects/zzucch/src/Lab4/Ui/Parsers/Parameters/DepthChainLink.cs",
            actual: success.CommandContext.Path?.Value);

        Assert.True(success.CommandContext.DisplayDriver is ConsoleDisplayDriver);
        Assert.True(success.CommandContext.FileSystemDriver is LocalFileSystemDriver);
    }

    [Fact]
    public void Handle_ShouldParseRequestProperly_WhenCorrectFileDeleteRequestPassed()
    {
        // Arrange
        IParseChainLink parseChain = GetParseChain();
        const string command = "file delete /home/pc/RiderProjects/zzucch/src/Lab4/Ui/Parsers/Parameters/DepthChainLink.cs";
        var request = new Request(
            new RequestStringIterator(command.Split()),
            new CommandContextBuilder());

        request.CommandContextBuilder.WithFileSystemDriver(new LocalFileSystemDriver());

        // Act
        ParseResult result = parseChain.Handle(request);

        // Assert
        Assert.True(result is ParseResult.Success);
        if (result is not ParseResult.Success success) return;
        Assert.True(success.CommandContext.Command is FileDeleteCommand);
        Assert.NotNull(success.CommandContext.Path);
        Assert.Equal(
            expected: "/home/pc/RiderProjects/zzucch/src/Lab4/Ui/Parsers/Parameters/DepthChainLink.cs",
            actual: success.CommandContext.Path?.Value);

        Assert.True(success.CommandContext.FileSystemDriver is LocalFileSystemDriver);
    }

    [Fact]
    public void Handle_ShouldParseRequestProperly_WhenCorrectDisconnectRequestPassed()
    {
        // Arrange
        IParseChainLink parseChain = GetParseChain();
        const string firstCommand = "connect /home/pc/RiderProjects -m local";
        var request = new Request(
            new RequestStringIterator(firstCommand.Split()),
            new CommandContextBuilder());

        parseChain.Handle(request);

        const string secondCommand = "disconnect";
        request = request with { Value = new RequestStringIterator(secondCommand.Split()) };

        // Act
        ParseResult result = parseChain.Handle(request);

        // Assert
        Assert.True(result is ParseResult.Success);
        if (result is not ParseResult.Success success) return;
        Assert.True(success.CommandContext.Command is DisconnectCommand);
    }

    [Fact]
    public void Handle_ShouldParseRequestProperly_WhenCorrectTreeListRequestPassed()
    {
        // Arrange
        IParseChainLink parseChain = GetParseChain();
        const string firstCommand = "connect /home/pc/RiderProjects -m local";
        var request = new Request(
            new RequestStringIterator(firstCommand.Split()),
            new CommandContextBuilder());

        parseChain.Handle(request);

        const string secondCommand = "tree list -d 12 -m console FD-";
        request = request with { Value = new RequestStringIterator(secondCommand.Split()) };

        // Act
        ParseResult result = parseChain.Handle(request);

        // Assert
        Assert.True(result is ParseResult.Success);
        if (result is not ParseResult.Success success) return;
        Assert.True(success.CommandContext.Command is TreeListCommand);
        Assert.Equal(expected: 12, actual: success.CommandContext.Depth);
        Assert.True(success.CommandContext.DisplayDriver is ConsoleDisplayDriver);
    }

    private static IParseChainLink GetParseChain()
    {
        IParseChainLink parseChain = new ConnectChainLink();
        parseChain.AddBranchNext(new TransitionalPathChainLink());
        parseChain.AddBranchNext(new MFlagChainLink());
        parseChain.AddBranchNext(new LocalFileSystemModeChainLink());

        parseChain.AddNext(new DisconnectChainLink());

        IParseChainLink treeChainLink = new TreeChainLink();

        IParseChainLink treeGotoChainLink = new TreeGotoChainLink();
        treeGotoChainLink.AddBranchNext(new FinalPathChainLink());

        IParseChainLink treeListChainLink = new TreeListChainLink();
        treeListChainLink.AddBranchNext(new DFlagChainLink());
        treeListChainLink.AddBranchNext(new DepthChainLink());
        treeListChainLink.AddBranchNext(new MFlagChainLink());
        treeListChainLink.AddBranchNext(new ConsoleDisplayModeChainLink());
        treeListChainLink.AddBranchNext(new TreeListParametersChainLink());
        treeGotoChainLink.AddNext(treeListChainLink);

        treeChainLink.AddBranchNext(treeGotoChainLink);
        parseChain.AddNext(treeChainLink);

        IParseChainLink fileChainLink = new FileChainLink();

        IParseChainLink fileShowChainLink = new FileShowChainLink();
        fileShowChainLink.AddBranchNext(new TransitionalPathChainLink());
        fileShowChainLink.AddBranchNext(new MFlagChainLink());
        fileShowChainLink.AddBranchNext(new ConsoleDisplayModeChainLink());

        IParseChainLink fileMoveChainLink = new FileMoveChainLink();
        fileMoveChainLink.AddBranchNext(new SourcePathChainLink());
        fileMoveChainLink.AddBranchNext(new DestinationPathChainLink());
        fileShowChainLink.AddNext(fileMoveChainLink);

        IParseChainLink fileCopyChainLink = new FileCopyChainLink();
        fileCopyChainLink.AddBranchNext(new SourcePathChainLink());
        fileCopyChainLink.AddBranchNext(new DestinationPathChainLink());
        fileShowChainLink.AddNext(fileCopyChainLink);

        IParseChainLink fileDeleteChainLink = new FileDeleteChainLink();
        fileDeleteChainLink.AddBranchNext(new FinalPathChainLink());
        fileShowChainLink.AddNext(fileDeleteChainLink);

        IParseChainLink fileRenameChainLink = new FileRenameChainLink();
        fileRenameChainLink.AddBranchNext(new TransitionalPathChainLink());
        fileRenameChainLink.AddBranchNext(new FileNameChainLink());
        fileShowChainLink.AddNext(fileRenameChainLink);

        fileChainLink.AddBranchNext(fileShowChainLink);
        parseChain.AddNext(fileChainLink);

        return parseChain;
    }
}