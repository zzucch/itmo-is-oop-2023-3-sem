using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Loggers;

public class FileWritingLogger : ILogger
{
    private const string LogFilePath = "info.log";

    public void LogInformation(string information)
    {
        StreamWriter writer = File.AppendText(LogFilePath);
        writer.WriteLine(information);
    }
}