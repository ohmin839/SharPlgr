using System.ComponentModel.Design;
using Sprache;

namespace SharPlgr.Api.ParserBuilder;

internal class CollectorBuilder
{
    internal Parser<IEnumerable<string>> BuildCollector()
    {
        return BuildWords().End();
    }

    private Parser<IEnumerable<string>> BuildWords()
    {
        var parser =
            from ws in Parse.AtLeastOnce(BuildWord().Or(BuildAnyChar()))
            select ws.Where(w => !string.IsNullOrEmpty(w));
        return parser;
    }

    private Parser<string> BuildWord()
    {
        var parser =
            from alphabets in Parse.AtLeastOnce(BuildAlphabet())
            from apostroph in Parse.String("'").Text().Optional()
            select string.Join("", alphabets) + apostroph.GetOrElse("");
        return parser;
    }

    private Parser<string> BuildAlphabet()
    {
        return BuildLargeAlpha()
                .Or(BuildLargeEpsilon())
                .Or(BuildLargeEta())
                .Or(BuildLargeIota())
                .Or(BuildLargeOmicron())
                .Or(BuildLargeUpsilon())
                .Or(BuildLargeOmega())
                .Or(BuildLargeRho())
                .Or(BuildLargeConsonant())
                .Or(BuildSmallAlpha())
                .Or(BuildSmallEpsilon())
                .Or(BuildSmallEta())
                .Or(BuildSmallIota())
                .Or(BuildSmallOmicron())
                .Or(BuildSmallUpsilon())
                .Or(BuildSmallOmega())
                .Or(BuildSmallRho())
                .Or(BuildSmallConsonant())
                ;
    }

    private Parser<string> BuildLargeAlpha()
    {
        return Parse.Regex("[ΑἈἌᾌἊᾊἎᾎᾈἉἍᾍἋᾋᾋἏᾉΆᾺᾼ]").Text();
    }

    private Parser<string> BuildLargeEpsilon()
    {
        return Parse.Regex("[ΕἘἜἚἙἝἛΈῈ]").Text();
    }

    private Parser<string> BuildLargeEta()
    {
        return Parse.Regex("[ΗἨἬᾜἪᾚἮᾞᾘἩἭᾝἫᾛᾛἯᾙΉῊῌ]").Text();
    }

    private Parser<string> BuildLargeIota()
    {
        return Parse.Regex("[ΙἸἼἺἾἹἽἻἿΊῚΪ]").Text();
    }

    private Parser<string> BuildLargeOmicron()
    {
        return Parse.Regex("[ΟὈὌὊὉὍὋΌῸ]").Text();
    }

    private Parser<string> BuildLargeUpsilon()
    {
        return Parse.Regex("[ΥὙὝὛὟΎῪΫ]").Text();
    }

    private Parser<string> BuildLargeOmega()
    {
        return Parse.Regex("[ΩὨὬᾬὪᾪὮᾮᾨὩὭᾭὫᾫᾫὯᾩΏῺῼ]").Text();
    }

    private Parser<string> BuildLargeRho()
    {
        return Parse.Regex("[ΡῬ]").Text();
    }

    private Parser<string> BuildLargeConsonant()
    {
        return Parse.Regex("[ΒΓΔΖΘΚΛΜΝΞΠΣΤΦΧΨ]").Text();
    }

    private Parser<string> BuildSmallAlpha()
    {
        return Parse.Regex("[αἀἄᾄἂᾂἆᾆᾀἁἅᾅἃᾃᾃἇᾁάᾴὰᾲᾶᾷᾳ]").Text();
    }

    private Parser<string> BuildSmallEpsilon()
    {
        return Parse.Regex("[εἐἔἒἑἕἓέὲ]").Text();
    }

    private Parser<string> BuildSmallEta()
    {
        return Parse.Regex("[ηἠἤᾔἢᾒἦᾖᾐἡἥᾕἣᾓᾓἧᾑήῄὴῂῆῇῃ]").Text();
    }

    private Parser<string> BuildSmallIota()
    {
        return Parse.Regex("[ιἰἴἲἶἱἵἳἷίὶῖϊΐῒῗ]").Text();
    }

    private Parser<string> BuildSmallOmicron()
    {
        return Parse.Regex("[οὀὄὂὁὅὃόὸ]").Text();
    }

    private Parser<string> BuildSmallUpsilon()
    {
        return Parse.Regex("[υὐὔὒὖὑὕὓὗύὺῦϋΰῢῧ]").Text();
    }

    private Parser<string> BuildSmallOmega()
    {
        return Parse.Regex("[ωὠὤᾤὢᾢὦᾦᾠὡὥᾥὣᾣᾣὧᾡώῴὼῲῶῷῳ]").Text();
    }

    private Parser<string> BuildSmallRho()
    {
        return Parse.Regex("[ρῤῥ]").Text();
    }

    private Parser<string> BuildSmallConsonant()
    {
        return Parse.Regex("[βγδζθκλμνξπσςτφχψ]").Text();
    }

    private Parser<string> BuildAnyChar()
    {
        var parser =
            from c in Parse.AnyChar
            select "";
        return parser;
    }
}