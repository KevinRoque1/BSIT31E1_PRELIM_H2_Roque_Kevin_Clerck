namespace ConsoleApp1;

using System.Xml.Linq;

public class XmlFileReader : BaseFileReader
{
    public override string SupportedFormat => "XML";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening XML stream...");

        var xdoc = XDocument.Load(filePath);

        string rootName = xdoc.Root?.Name.ToString() ?? "(no root)";

        int descendantCount = xdoc.Descendants().Count();

        Console.WriteLine($" -> Root element: <{rootName}> with {descendantCount} descendant nodes.");

        string xmlText = xdoc.ToString();

        string displayContent = xmlText.Length > 100
            ? xmlText.Substring(0, 100) + ". . . "
            : xmlText;

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}