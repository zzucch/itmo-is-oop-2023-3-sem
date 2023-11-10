namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Renderables;

public class Text : IText<Text>
{
    public Text(string content)
    {
        Content = content;
    }

    private string Content { get; }

    public string Render()
    {
        return Content;
    }
}