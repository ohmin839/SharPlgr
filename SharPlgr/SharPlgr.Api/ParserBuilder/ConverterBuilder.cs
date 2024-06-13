using Sprache;

namespace SharPlgr.Api.ParserBuilder;
internal partial class ConverterBuilder
{
    internal Parser<string> BuildConverter()
    {
        return BuildLetters().End();
    }

    private Parser<string> BuildLetters()
    {
        var parser =
            from letters in Parse.AtLeastOnce(BuildLetter())
            select string.Join("", letters);
        return parser;
    }

    private Parser<string> BuildLetter()
    {
        var parser = 
            BuildAlphabet()
            .Or(BuildPunctuation())
            .Or(BuildAnyChar())
            ;
        return parser;
    }

    private Parser<string> BuildAlphabet()
    {
        var parser = 
            BuildLargeAlpha()
            .Or(BuildLargeEpsilon())
            .Or(BuildLargeEta())
            .Or(BuildLargeIota())
            .Or(BuildLargeOmicron())
            .Or(BuildLargeUpsilon())
            .Or(BuildLargeOmega())
            .Or(BuildLargeBeta())
            .Or(BuildLargeGamma())
            .Or(BuildLargeDelta())
            .Or(BuildLargeZeta())
            .Or(BuildLargeKappa())
            .Or(BuildLargeLambda())
            .Or(BuildLargeMu())
            .Or(BuildLargeNu())
            .Or(BuildLargeXi())
            .Or(BuildLargePi())
            .Or(BuildLargeRho())
            .Or(BuildLargeSigma())
            .Or(BuildLargeTau())
            .Or(BuildSmallAlpha())
            .Or(BuildSmallEpsilon())
            .Or(BuildSmallEta())
            .Or(BuildSmallIota())
            .Or(BuildSmallOmicron())
            .Or(BuildSmallUpsilon())
            .Or(BuildSmallOmega())
            .Or(BuildSmallBeta())
            .Or(BuildSmallGamma())
            .Or(BuildSmallDelta())
            .Or(BuildSmallZeta())
            .Or(BuildSmallKappa())
            .Or(BuildSmallLambda())
            .Or(BuildSmallMu())
            .Or(BuildSmallNu())
            .Or(BuildSmallXi())
            .Or(BuildSmallPi())
            .Or(BuildSmallRho())
            .Or(BuildSmallSigma())
            .Or(BuildSmallTau())
            ;
        return parser;
    }

    private Parser<string> BuildLargeAlpha()
    {
        var parser =
            from text in Parse.Regex("[<>]?['`~]?A\\|?")
            select ConvertLargeAlpha(text);
        return parser;
    }

    private Parser<string> BuildLargeEpsilon()
    {
        var parser =
            from text in Parse.Regex("[<>]?['`]?E")
            select ConvertLargeEpsilon(text);
        return parser;
    }

    private Parser<string> BuildLargeEta()
    {
        var parser =
            from text in Parse.Regex("[<>]?['`~]?\\^E\\|?")
            select ConvertLargeEta(text);
        return parser;
    }

    private Parser<string> BuildLargeIota()
    {
        var parser =
            from text in Parse.Regex("[<>\"]?['`~]?I")
            select ConvertLargeIota(text);
        return parser;
    }

    private Parser<string> BuildLargeOmicron()
    {
        var parser =
            from text in Parse.Regex("[<>]?['`]?O")
            select ConvertLargeOmicron(text);
        return parser;
    }

    private Parser<string> BuildLargeUpsilon()
    {
        var parser =
            from text in Parse.Regex("[<>\"]?['`~]?[UY]")
            select ConvertLargeUpsilon(text);
        return parser;
    }

    private Parser<string> BuildLargeOmega()
    {
        var parser =
            from text in Parse.Regex("[<>]?['`~]?\\^O\\|?")
            select ConvertLargeOmega(text);
        return parser;
    }
    
    private Parser<string> BuildLargeBeta()
    {
        var parser =
            from _ in Parse.String("B")
            select ConvertLargeBeta();
        return parser;
    }

    private Parser<string> BuildLargeGamma()
    {
        var parser =
            from _ in Parse.String("G")
            select ConvertLargeGamma();
        return parser;
    }

    private Parser<string> BuildLargeDelta()
    {
        var parser =
            from _ in Parse.String("D")
            select ConvertLargeDelta();
        return parser;
    }

    private Parser<string> BuildLargeZeta()
    {
        var parser =
            from _ in Parse.String("Z")
            select ConvertLargeZeta();
        return parser;
    }

    private Parser<string> BuildLargeKappa()
    {
        var parser =
            from text in Parse.Regex("Kh?")
            select ConvertLargeKappa(text);
        return parser;
    }

    private Parser<string> BuildLargeLambda()
    {
        var parser =
            from _ in Parse.String("L")
            select ConvertLargeLambda();
        return parser;
    }

    private Parser<string> BuildLargeMu()
    {
        var parser =
            from _ in Parse.String("M")
            select ConvertLargeMu();
        return parser;
    }

    private Parser<string> BuildLargeNu()
    {
        var parser =
            BuildLargeNasableGamma()
            .Or(BuildLargeSingleNu());
        return parser;
    }

    private Parser<string> BuildLargeNasableGamma()
    {
        var parser =
            from n in Parse.String("N")
            from g in BuildLargeGamma()
                        .Or(BuildLargeKappa())
                        .Or(BuildLargeXi())
            select ConvertLargeGamma() + g;
        return parser;
    }

    private Parser<string> BuildLargeSingleNu()
    {
        var parser =
            from _ in Parse.String("N")
            select ConvertLargeNu();
        return parser;
    }

    private Parser<string> BuildLargeXi()
    {
        var parser = 
            from _ in Parse.String("X")
            select ConvertLargeXi();
        return parser;
    }

    private Parser<string> BuildLargePi()
    {
        var parser = 
            from text in Parse.Regex("P[hs]?")
            select ConvertLargePi(text);
        return parser;
    }

    private Parser<string> BuildLargeRho()
    {
        var parser =
            from text in Parse.Regex("<?R")
            select ConvertLargeRho(text);
        return parser;
    }

    private Parser<string> BuildLargeSigma()
    {
        var parser =
            from _ in Parse.String("S")
            select ConvertLargeSigma();
        return parser;
    }

    private Parser<string> BuildLargeTau()
    {
        var parser = 
            from text in Parse.Regex("Th?")
            select ConvertLargeTau(text);
        return parser;
    }


    private Parser<string> BuildSmallAlpha()
    {
        var parser =
            from text in Parse.Regex("[<>]?['`~]?a\\|?")
            select ConvertSmallAlpha(text);
        return parser;
    }

    private Parser<string> BuildSmallEpsilon()
    {
        var parser =
            from text in Parse.Regex("[<>]?['`]?e")
            select ConvertSmallEpsilon(text);
        return parser;
    }

    private Parser<string> BuildSmallEta()
    {
        var parser =
            from text in Parse.Regex("[<>]?['`~]?\\^e\\|?")
            select ConvertSmallEta(text);
        return parser;
    }

    private Parser<string> BuildSmallIota()
    {
        var parser =
            from text in Parse.Regex("[<>\"]?['`~]?i")
            select ConvertSmallIota(text);
        return parser;
    }

    private Parser<string> BuildSmallOmicron()
    {
        var parser =
            from text in Parse.Regex("[<>]?['`]?o")
            select ConvertSmallOmicron(text);
        return parser;
    }

    private Parser<string> BuildSmallUpsilon()
    {
        var parser =
            from text in Parse.Regex("[<>\"]?['`~]?[uy]")
            select ConvertSmallUpsilon(text);
        return parser;
    }

    private Parser<string> BuildSmallOmega()
    {
        var parser =
            from text in Parse.Regex("[<>]?['`~]?\\^o\\|?")
            select ConvertSmallOmega(text);
        return parser;
    }
    
    private Parser<string> BuildSmallBeta()
    {
        var parser =
            from _ in Parse.String("b")
            select ConvertSmallBeta();
        return parser;
    }

    private Parser<string> BuildSmallGamma()
    {
        var parser =
            from _ in Parse.String("g")
            select ConvertSmallGamma();
        return parser;
    }

    private Parser<string> BuildSmallDelta()
    {
        var parser =
            from _ in Parse.String("d")
            select ConvertSmallDelta();
        return parser;
    }

    private Parser<string> BuildSmallZeta()
    {
        var parser =
            from _ in Parse.String("z")
            select ConvertSmallZeta();
        return parser;
    }

    private Parser<string> BuildSmallKappa()
    {
        var parser =
            from text in Parse.Regex("kh?")
            select ConvertSmallKappa(text);
        return parser;
    }

    private Parser<string> BuildSmallLambda()
    {
        var parser =
            from _ in Parse.String("l")
            select ConvertSmallLambda();
        return parser;
    }

    private Parser<string> BuildSmallMu()
    {
        var parser =
            from _ in Parse.String("m")
            select ConvertSmallMu();
        return parser;
    }

    private Parser<string> BuildSmallNu()
    {
        var parser =
            BuildSmallNasableGamma()
            .Or(BuildSmallSingleNu());
        return parser;
    }

    private Parser<string> BuildSmallNasableGamma()
    {
        var parser =
            from n in Parse.String("n")
            from g in BuildSmallGamma()
                        .Or(BuildSmallKappa())
                        .Or(BuildSmallXi())
            select ConvertSmallGamma() + g;
        return parser;
    }

    private Parser<string> BuildSmallSingleNu()
    {
        var parser =
            from _ in Parse.String("n")
            select ConvertSmallNu();
        return parser;
    }

    private Parser<string> BuildSmallXi()
    {
        var parser = 
            from _ in Parse.String("x")
            select ConvertSmallXi();
        return parser;
    }

    private Parser<string> BuildSmallPi()
    {
        var parser = 
            from text in Parse.Regex("p[hs]?")
            select ConvertSmallPi(text);
        return parser;
    }

    private Parser<string> BuildSmallRho()
    {
        var parser =
            from text in Parse.Regex("[<>]?r")
            select ConvertSmallRho(text);
        return parser;
    }

    private Parser<string> BuildSmallSigma()
    {
        var parser =
            BuildSmallLeadingSigma()
            .Or(BuildSmallSingleSigma());
        return parser;
    }

    private Parser<string> BuildSmallLeadingSigma()
    {
        var parser =
            from _ in Parse.String("s")
            from a in BuildAlphabet()
            select ConvertLeadingSigma() + a;
        return parser;
    }

    private Parser<string> BuildSmallSingleSigma()
    {
        var parser =
            from text in Parse.Regex("[cs]")
            select ConvertSmallSigma(text);
        return parser;
    }

    private Parser<string> BuildSmallTau()
    {
        var parser = 
            from text in Parse.Regex("th?")
            select ConvertSmallTau(text);
        return parser;
    }

    private Parser<string> BuildPunctuation()
    {
        var parser =
            BuildSemicoron()
            .Or(BuildQuestion())
            ;
        return parser;
    }

    private Parser<string> BuildSemicoron()
    {
        var parser =
            from _ in Parse.String(";")
            select ConvertSemicoron();
        return parser;
    }

    private Parser<string> BuildQuestion()
    {
        var parser =
            from _ in Parse.String("?")
            select ConvertQuestion();
        return parser;
    }

    private Parser<string> BuildAnyChar()
    {
        var parser = 
            from ch in Parse.AnyChar
            select ch.ToString();
        return parser;
    }
}