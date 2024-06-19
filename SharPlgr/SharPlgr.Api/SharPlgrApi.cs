using SharPlgr.Api.ParserBuilder;
using Sprache;

namespace SharPlgr.Api;

public class SharPlgrApi
{
    private static readonly Parser<string> CONVERTER;
    private static readonly Parser<IEnumerable<string>> COLLECTOR;

    static SharPlgrApi()
    {
        ConverterBuilder converterBuilder = new ConverterBuilder();
        CONVERTER = converterBuilder.BuildConverter();

        CollectorBuilder collectorBuilder = new CollectorBuilder();
        COLLECTOR = collectorBuilder.BuildCollector();
    }

    public static string ConvertToPolytonicText(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }
        else
        {
            return CONVERTER.Parse(text);
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
            return COLLECTOR.Parse(text).ToList();
        }
    }
}
