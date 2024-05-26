namespace SharPlgr.Api.ParserBuilder;

internal partial class ConverterBuilder {
    private int CalculateScore(string text)
    {
        return AddScoreIfDialesis(text,
                AddScoreIfBreath(text,
                AddScoreIfAccent(text,
                AddScoreIfIotaSubscriptum(text))));
    }

    private int AddScoreIfDialesis(string text, int score = 0)
    {
        if (text.Contains("\""))
        {
            return 64 + score;
        }
        return score;
    }

    private int AddScoreIfBreath(string text, int score = 0)
    {
        if (text.Contains("<"))
        {
            return 16 + score;
        }
        if (text.Contains(">"))
        {
            return 32 + score;
        }
        return score;
    }

    private int AddScoreIfAccent(string text, int score = 0)
    {
        if (text.Contains("'"))
        {
            return  4 + score;
        }
        if (text.Contains("`"))
        {
            return  8 + score;
        }
        if (text.Contains("~"))
        {
            return 12 + score;
        }
        return score;
    }

    private int AddScoreIfIotaSubscriptum(string text, int score = 0)
    {
        if (text.Contains("|"))
        {
            return 1 + score;
        }
        return score;
    }

    private string ConvertLargeAlpha(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
            case 1: return "\u1FBC"; // A|
            case 4: return "\u1FBB"; // 'A
            //case  5: return "\uxxxx"; // 'A|
            case 8: return "\u1FBA"; // `A
            //case  9: return "\uxxxx"; // `A|
            //case 12: return "\uxxxx"; // ~A
            //case 13: return "\uxxxx"; // ~A|
            case 16: return "\u1F09"; // <A
            case 17: return "\u1F89"; // <A|
            case 20: return "\u1F0D"; // <'A
            case 21: return "\u1F8D"; // <'A|
            case 24: return "\u1F0B"; // <`A
            case 25: return "\u1F8B"; // <`A|
            case 28: return "\u1F0F"; // <~A
            case 29: return "\u1F8F"; // <`A|
            case 32: return "\u1F08"; // >A
            case 33: return "\u1F88"; // >A|
            case 36: return "\u1F0C"; // >'A
            case 37: return "\u1F8C"; // >'A|
            case 40: return "\u1F0A"; // >`A
            case 41: return "\u1F8A"; // >`A|
            case 44: return "\u1F0E"; // >~A
            case 45: return "\u1F8E"; // >~A|
            default: return "\u0391"; // A
        }
    }

    private string ConvertLargeEpsilon(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
            case  4: return "\u1FC9"; // 'E
            case  8: return "\u1FC8"; // `E
            case 16: return "\u1F19"; // <E
            case 20: return "\u1F1D"; // <'E
            case 24: return "\u1F1B"; // <`E
            case 32: return "\u1F18"; // >E
            case 36: return "\u1F1C"; // >'E
            case 40: return "\u1F1A"; // >`E
            default: return "\u0395"; // E        
        }
    }

    private string ConvertLargeEta(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
            case  1: return "\u1FCC"; // ^E|
            case  4: return "\u1FCB"; // '^E
            // case  5: return "\xxxxx"; // '^E|
            case  8: return "\u1FCA"; // `^E
            // case  9: return "\xxxxx"; // `^E|
            // case 12: return "\xxxxx"; // ~^E
            // case 13: return "\xxxxx"; // ~^E|
            case 16: return "\u1F29"; // <^E
            case 17: return "\u1F99"; // <^E|
            case 20: return "\u1F2D"; // <'^E
            case 21: return "\u1F9D"; // <'^E|
            case 24: return "\u1F2B"; // <`^E
            case 25: return "\u1F9B"; // <`^E|
            case 28: return "\u1F2F"; // <~^E
            case 29: return "\u1F9F"; // <`^E|
            case 32: return "\u1F28"; // >^E
            case 33: return "\u1F98"; // >^E|
            case 36: return "\u1F2C"; // >'^E
            case 37: return "\u1F9C"; // >'^E|
            case 40: return "\u1F2A"; // >`^E
            case 41: return "\u1F9A"; // >`^E|
            case 44: return "\u1F2E"; // >~^E
            case 45: return "\u1F9E"; // >~^E|
            default: return "\u0397"; // ^E
        }
    }

    private string ConvertLargeIota(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
           case  4: return "\u1FDB"; // 'I
           case  8: return "\u1FDA"; // `I
           // case  12: return "\xxxxx"; // ~I
           case 16: return "\u1F39"; // <I
           case 20: return "\u1F3D"; // <'I
           case 24: return "\u1F3B"; // <`I
           case 28: return "\u1F3F"; // <~I
           case 32: return "\u1F38"; // >I
           case 36: return "\u1F3C"; // >'I
           case 40: return "\u1F3A"; // >`I
           case 44: return "\u1F3E"; // >~I
           case 64: return "\u03AA"; // "I
           default: return "\u0399"; // I
       }    
    }

    private string ConvertLargeOmicron(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
            case  4: return "\u1FF9"; // 'O
            case  8: return "\u1FF8"; // `O
            case 16: return "\u1F49"; // <O
            case 20: return "\u1F4D"; // <'O
            case 24: return "\u1F4B"; // <`O
            case 32: return "\u1F48"; // >O
            case 36: return "\u1F4C"; // >'O
            case 40: return "\u1F4A"; // >`O
            default: return "\u039F"; // O
        }
    }

    private string ConvertLargeUpsilon(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
            case  4: return "\u1FEB"; // 'Y
            case  8: return "\u1FEA"; // `Y
            // case  12: return "\xxxxx"; // ~Y
            case 16: return "\u1F59"; // <Y
            case 20: return "\u1F5D"; // <'Y
            case 24: return "\u1F5B"; // <`Y
            case 28: return "\u1F5F"; // <~Y
            case 64: return "\u03AB"; // "Y
            default: return "\u03A5"; // Y
        }
    }

    private string ConvertLargeOmega(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
            case  1: return "\u1FFC"; // ^O|
            case  4: return "\u1FFB"; // '^O
            // case  5: return "\xxxxx"; // '^O|
            case  8: return "\u1FFA"; // `^O
            // case  9: return "\xxxxx"; // `^O|
            // case 12: return "\xxxxx"; // ~^O
            // case 13: return "\xxxxx"; // ~^O|
            case 16: return "\u1F69"; // <^O
            case 17: return "\u1FA9"; // <^O|
            case 20: return "\u1F6D"; // <'^O
            case 21: return "\u1FAD"; // <'^O|
            case 24: return "\u1F6B"; // <`^O
            case 25: return "\u1FAB"; // <`^O|
            case 28: return "\u1F6F"; // <~^O
            case 29: return "\u1FAF"; // <`^O|
            case 32: return "\u1F68"; // >^O
            case 33: return "\u1FA8"; // >^O|
            case 36: return "\u1F6C"; // >'^O
            case 37: return "\u1FAC"; // >'^O|
            case 40: return "\u1F6A"; // >`^O
            case 41: return "\u1FAA"; // >`^O|
            case 44: return "\u1F6E"; // >~^O
            case 45: return "\u1FAE"; // >~^O|
            default: return "\u03A9"; // ^O
        }
    }

    private string ConvertLargeBeta()
    {
        return "\u0392";
    }

    private string ConvertLargeGamma()
    {
        return "\u0393";
    }

    private string ConvertLargeDelta()
    {
        return "\u0394";
    }

    private string ConvertLargeZeta()
    {
        return "\u0396";
    }

    private string ConvertLargeKappa(string text)
    {
        if (text.Contains("h"))
        {
            return "\u03A7"; // large khi
        }
        else
        {
            return "\u039A"; // large kappa
        }
    }

    private string ConvertLargeLambda()
    {
        return "\u039B";
    }

    private string ConvertLargeMu()
    {
        return "\u039C";
    }

    private string ConvertLargeNu()
    {
        return "\u039D";
    }

    private string ConvertLargeXi()
    {
        return "\u039E";
    }

    private string ConvertLargePi(string text)
    {
        if (text.EndsWith("h"))
        {
            return "\u03A6"; // large phi
        }
        else if (text.EndsWith("s"))
        {
            return "\u03A8"; // large psi
        }
        else
        {
            return "\u03A0"; // large pi
        }
    }
    private string ConvertLargeRho(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
            case 16: return "\u1FEC"; // <R
            default: return "\u03A1"; // R
        }
    }
    private string ConvertLargeSigma()
    {
        return "\u03A3";
    }
    private string ConvertLargeTau(string text)
    {
        if (text.EndsWith("h"))
        {
            return "\u0398"; // large theta
        }
        else
        {
            return "\u03A4"; // large tau
        }
    }

    private string ConvertSmallAlpha(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
            case  1: return "\u1FB3"; // a|
            case  4: return "\u1F71"; // 'a
            case  5: return "\u1FB4"; // 'a|
            case  8: return "\u1F70"; // `a
            case  9: return "\u1FB2"; // `a|
            case 12: return "\u1FB6"; // ~a
            case 13: return "\u1FB7"; // ~a|
            case 16: return "\u1F01"; // <a
            case 17: return "\u1F81"; // <a|
            case 20: return "\u1F05"; // <'a
            case 21: return "\u1F85"; // <'a|
            case 24: return "\u1F03"; // <`a
            case 25: return "\u1F83"; // <`a|
            case 28: return "\u1F07"; // <~a
            case 29: return "\u1F87"; // <`a|
            case 32: return "\u1F00"; // >a
            case 33: return "\u1F80"; // >a|
            case 36: return "\u1F04"; // >'a
            case 37: return "\u1F84"; // >'a|
            case 40: return "\u1F02"; // >`a
            case 41: return "\u1F82"; // >`a|
            case 44: return "\u1F06"; // >~a
            case 45: return "\u1F86"; // >~a|
            default: return "\u03B1"; // a
        }
    }

    private string ConvertSmallEpsilon(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
            case  4: return "\u1F73"; // 'e
            case  8: return "\u1F72"; // `e
            case 16: return "\u1F11"; // <e
            case 20: return "\u1F15"; // <'e
            case 24: return "\u1F13"; // <`e
            case 32: return "\u1F10"; // >e
            case 36: return "\u1F14"; // >'e
            case 40: return "\u1F12"; // >`e
            default: return "\u03B5"; // e
        }
    }

    private string ConvertSmallEta(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
            case  1: return "\u1FC3"; // ^e|
            case  4: return "\u1F75"; // '^e
            case  5: return "\u1FC4"; // '^e|
            case  8: return "\u1F74"; // `^e
            case  9: return "\u1FC2"; // `^e|
            case 12: return "\u1FC6"; // ~^e
            case 13: return "\u1FC7"; // ~^e|
            case 16: return "\u1F21"; // <^e
            case 17: return "\u1F91"; // <^e|
            case 20: return "\u1F25"; // <'^e
            case 21: return "\u1F95"; // <'^e|
            case 24: return "\u1F23"; // <`^e
            case 25: return "\u1F93"; // <`^e|
            case 28: return "\u1F27"; // <~^e
            case 29: return "\u1F97"; // <`^e|
            case 32: return "\u1F20"; // >^e
            case 33: return "\u1F90"; // >^e|
            case 36: return "\u1F24"; // >'^e
            case 37: return "\u1F94"; // >'^e|
            case 40: return "\u1F22"; // >`^e
            case 41: return "\u1F92"; // >`^e|
            case 44: return "\u1F26"; // >~^e
            case 45: return "\u1F96"; // >~^e|
            default: return "\u03B7"; // ^e
        }
    }

    private string ConvertSmallIota(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
            case  4: return "\u1F77"; // 'i
            case  8: return "\u1F76"; // `i
            case 12: return "\u1FD6"; // ~i
            case 16: return "\u1F31"; // <i
            case 20: return "\u1F35"; // <'i
            case 24: return "\u1F33"; // <`i
            case 28: return "\u1F37"; // <~i
            case 32: return "\u1F30"; // >i
            case 36: return "\u1F34"; // >'i
            case 40: return "\u1F32"; // >`i
            case 44: return "\u1F36"; // >~i
            case 64: return "\u03CA"; // "i
            case 68: return "\u1FD3"; // "'i
            case 72: return "\u1FD2"; // "`i
            case 76: return "\u1FD7"; // "~i
            default: return "\u03B9"; // i 
        }
    }

    private string ConvertSmallOmicron(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
            case  4: return "\u1F79"; // 'o
            case  8: return "\u1F78"; // `o
            case 16: return "\u1F41"; // <o
            case 20: return "\u1F45"; // <'o
            case 24: return "\u1F43"; // <`o
            case 32: return "\u1F40"; // >o
            case 36: return "\u1F44"; // >'o
            case 40: return "\u1F42"; // >`o
            default: return "\u03BF"; // o
        }
    }

    private string ConvertSmallUpsilon(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
            case  4: return "\u1F7B"; // 'y
            case  8: return "\u1F7A"; // `y
            case 12: return "\u1FE6"; // ~y
            case 16: return "\u1F51"; // <y
            case 20: return "\u1F55"; // <'y
            case 24: return "\u1F53"; // <`y
            case 28: return "\u1F57"; // <~y
            case 32: return "\u1F50"; // >y
            case 36: return "\u1F54"; // >'y
            case 40: return "\u1F52"; // >`y
            case 44: return "\u1F56"; // >~y
            case 64: return "\u03CB"; // "y
            case 68: return "\u1FE3"; // "'y
            case 72: return "\u1FE2"; // "`y
            case 76: return "\u1FE7"; // "~y
            default: return "\u03C5"; // y
        }
    }

    private string ConvertSmallOmega(string text)
    {
        var score  = CalculateScore(text);
        switch (score)
        {
            case  1: return "\u1FF3"; // ^o|
            case  4: return "\u1F7D"; // '^o
            case  5: return "\u1FF4"; // '^o|
            case  8: return "\u1F7C"; // `^o
            case  9: return "\u1FF2"; // `^o|
            case 12: return "\u1FF6"; // ~^o
            case 13: return "\u1FF7"; // ~^o|
            case 16: return "\u1F61"; // <^o
            case 17: return "\u1FA1"; // <^o|
            case 20: return "\u1F65"; // <'^o
            case 21: return "\u1FA5"; // <'^o|
            case 24: return "\u1F63"; // <`^o
            case 25: return "\u1FA3"; // <`^o|
            case 28: return "\u1F67"; // <~^o
            case 29: return "\u1FA7"; // <`^o|
            case 32: return "\u1F60"; // >^o
            case 33: return "\u1FA0"; // >^o|
            case 36: return "\u1F64"; // >'^o
            case 37: return "\u1FA4"; // >'^o|
            case 40: return "\u1F62"; // >`^o
            case 41: return "\u1FA2"; // >`^o|
            case 44: return "\u1F66"; // >~^o
            case 45: return "\u1FA6"; // >~^o|
            default: return "\u03C9"; // ^o
        }
    }

    private string ConvertSmallBeta()
    {
        return "\u03B2";
    }

    private string ConvertSmallGamma()
    {
        return "\u03B3";
    }

    private string ConvertSmallDelta()
    {
        return "\u03B4";
    }

    private string ConvertSmallZeta()
    {
        return "\u03B6";
    }

    private string ConvertSmallKappa(string text)
    {
        if (text.Contains("h"))
        {
            return "\u03C7"; // small khi
        }
        else
        {
            return "\u03BA"; // small kappa
        }
    }

    private string ConvertSmallLambda()
    {
        return "\u03BB";
    }

    private string ConvertSmallMu()
    {
        return "\u03BC";
    }

    private string ConvertSmallNu()
    {
        return "\u03BD";
    }

    private string ConvertSmallXi()
    {
        return "\u03BE";
    }

    private string ConvertSmallPi(string text)
    {
        if (text.EndsWith("h"))
        {
            return "\u03C6"; // small phi
        }
        else if (text.EndsWith("s"))
        {
            return "\u03C8"; // small psi
        }
        else
        {
            return "\u03C0"; // small pi
        }
    }

    private string ConvertSmallRho(string text)
    {
        var score = CalculateScore(text);
        switch (score)
        {
            case 16: return "\u1FE5";
            case 32: return "\u1FE4";
            default: return "\u03C1";
        }
    }

    private string ConvertSmallSigma(string text)
    {
        if ("s".Equals(text))
        {
            return ConvertFinalSigma();
        }
        else
        {
            return ConvertLeadingSigma();
        }
    }

    private string ConvertFinalSigma()
    {
        return "\u03C2";
    }

    private string ConvertLeadingSigma()
    {
        return "\u03C3";
    }

    private string ConvertSmallTau(string text)
    {
        if (text.EndsWith("h")) {
            return "\u03B8"; // small theta
        } else {
            return "\u03C4"; // small tau
        }
    }

    private string ConvertSemicoron()
    {
        return "\u0387";
    }
    private string ConvertQuestion()
    {
        return "\u037E";
    }
}