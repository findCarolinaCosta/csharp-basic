namespace Helpers.Tests;

public static class ConsoleOutput
{
    public static string Capture(Action action)
    {
        var originalOut = Console.Out;
        using (var writer = new StringWriter())
        {
            Console.SetOut(writer);
            action();
            Console.SetOut(originalOut);
            return writer.ToString().Trim();
        }
    }
}
