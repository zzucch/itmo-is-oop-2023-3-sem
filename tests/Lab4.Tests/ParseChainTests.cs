using Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Models.Parameters;
using Itmo.ObjectOrientedProgramming.Lab4.Execution.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Disconnect;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.File.Copies;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.File.Deletes;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.File.Moves;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.File.Renames;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.File.Shows;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Tree.Gotos;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Parsers.Commands.Tree.Lists;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests;
using Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests.Iterators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParseChainTests
{
    [Theory]
    [InlineData("connect /home/pc/RiderProjects -m local")]
    [InlineData("file show /home/pc/RiderProjects/zzucch/tests/Lab4.Tests/ParseChainTests.cs -m console")]
    [InlineData("file delete /home/pc/RiderProjects/zzucch/tests/Lab4.Tests/ParseChainTests.cs")]
    [InlineData("disconnect")]
    [InlineData("tree list -d 12")]
    [InlineData("file rename /home/pc/RiderProjects/zzucch/tests/Lab4.Tests/ParseChainTests.cs OtherName.cs")]
    [InlineData("tree goto /home/pc/RiderProjects/zzucch/tests/Lab4.Tests/")]
    [InlineData("file copy /home/pc/RiderProjects/zzucch/tests/Lab4.Tests/ParseChainTests.cs /home/pc/RiderProjects/zzucch/tests/Lab4.Tests/ParseChainTestsCopy.cs")]
    public void Handle_ShouldParseRequestProperly_WhenCorrectRequestPassed(string command)
    {
        // Arrange
        IParseChainLink parseChain = GetParseChain();
        var request = new Request(new RequestStringIterator(command.Split()));

        // Act
        ParseResult result = parseChain.Handle(request);

        // Assert
        Assert.True(result is ParseResult.Success);
    }

    private static IParseChainLink GetParseChain()
    {
        var displayDriver = new ConsoleDisplayDriver();

        IParseChainLink parseChain = new ConnectChainLink(null, displayDriver);

        parseChain.AddNext(new DisconnectChainLink(null, displayDriver));

        IParseChainLink treeGotoChainLink = new TreeGotoChainLink(null, displayDriver);
        IParseChainLink treeListChainLink = new TreeListChainLink(
            null,
            displayDriver,
            new Visitor(new TreeListParameters('F', 'D', '-')));

        treeGotoChainLink.AddNext(treeListChainLink);

        IParseChainLink treeChainLink = new TreeChainLink(treeGotoChainLink);
        parseChain.AddNext(treeChainLink);

        IParseChainLink fileShowChainLink = new FileShowChainLink(null, displayDriver);
        IParseChainLink fileMoveChainLink = new FileMoveChainLink(null, displayDriver);
        fileShowChainLink.AddNext(fileMoveChainLink);

        IParseChainLink fileCopyChainLink = new FileCopyChainLink(null, displayDriver);
        fileShowChainLink.AddNext(fileCopyChainLink);

        IParseChainLink fileDeleteChainLink = new FileDeleteChainLink(null, displayDriver);
        fileShowChainLink.AddNext(fileDeleteChainLink);

        IParseChainLink fileRenameChainLink = new FileRenameChainLink(null, displayDriver);
        fileShowChainLink.AddNext(fileRenameChainLink);

        IParseChainLink fileChainLink = new FileChainLink(fileShowChainLink);
        parseChain.AddNext(fileChainLink);

        return parseChain;
    }
}