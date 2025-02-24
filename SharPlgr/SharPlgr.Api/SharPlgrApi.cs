using SharPlgr.Api.ParserBuilder;
using Sprache;

namespace SharPlgr.Api;

public class SharPlgrApi
{
    private static readonly ConverterBuilder CONVERTER_BUILDER;
    private static readonly CollectorBuilder COLLECTOR_BUILDER;

    static SharPlgrApi()
    {
        CONVERTER_BUILDER = new ConverterBuilder();
        COLLECTOR_BUILDER = new CollectorBuilder();
    }

    public static string ConvertToPolytonicText(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }
        else
        {
            var converter = CONVERTER_BUILDER.BuildConverter();
            return converter.Parse(text);
        }
    }

    public static List<string> CollectPolytonicWords(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return [];
        }
        else
        {
            var collector = COLLECTOR_BUILDER.BuildCollector();
            return collector.Parse(text).ToList();
        }
    }
}
