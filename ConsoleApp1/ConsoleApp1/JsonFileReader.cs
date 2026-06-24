namespace ConsoleApp1;

using System.Text.Json;

public class JsonFileReader : BaseFileReader
{
    public override string SupportedFormat => "JSON";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening JSON stream...");

        string raw = File.ReadAllText(filePath);

        using var doc = JsonDocument.Parse(raw);
        var root = doc.RootElement;

        int count;
        switch (root.ValueKind)
        {
            case JsonValueKind.Object:
                count = root.EnumerateObject().Count();
                Console.WriteLine($" -> Parsed {count} root properties.");
                break;

            case JsonValueKind.Array:
                count = root.EnumerateArray().Count();
                Console.WriteLine($" -> Parsed {count} root array items.");
                break;

            default:
                count = 1;
                Console.WriteLine(" -> Parsed root JSON value.");
                break;
        }

        string displayContent = raw.Length > 100
           ? raw.Substring(0, 100) + "..."
           : raw;

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}