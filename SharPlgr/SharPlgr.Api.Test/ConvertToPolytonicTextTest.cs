using System.Collections;
using static SharPlgr.Api.SharPlgrApi;

namespace SharPlgr.Api.Test;

public class ConvertToPolytonicTextTest
{
    [Theory]
    [ClassData(typeof(TestData))]
    public void TestMethod(string argument, string expected)
    {
        var actual = ConvertToPolytonicText(argument);
        Assert.Equal(expected, actual);
    }

    class TestData : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator()
        {
            // null or empoty
            yield return new object?[] { null, "" };
            yield return new object?[] { "", "" };
            // large alpha
            yield return new object?[] { "A", "Α" };
            yield return new object?[] { "A|", "ᾼ" };
            yield return new object?[] { "'A", "Ά" };
            yield return new object?[] { "`A", "Ὰ" };
            yield return new object?[] { "<A", "Ἁ" };
            yield return new object?[] { "<A|", "ᾉ" };
            yield return new object?[] { "<'A", "Ἅ" };
            yield return new object?[] { "<'A|", "ᾍ" };
            yield return new object?[] { "<`A", "Ἃ" };
            yield return new object?[] { "<`A|", "ᾋ" };
            yield return new object?[] { "<~A", "Ἇ" };
            yield return new object?[] { "<~A|", "ᾏ" };
            yield return new object?[] { ">A", "Ἀ" };
            yield return new object?[] { ">A|", "ᾈ" };
            yield return new object?[] { ">'A", "Ἄ" };
            yield return new object?[] { ">'A|", "ᾌ" };
            yield return new object?[] { ">`A", "Ἂ" };
            yield return new object?[] { ">`A|", "ᾊ" };
            yield return new object?[] { ">~A", "Ἆ" };
            yield return new object?[] { ">~A|", "ᾎ" };
            // large epsilon
            yield return new object?[] { "E", "Ε" };
            yield return new object?[] { "'E", "Έ" };
            yield return new object?[] { "`E", "Ὲ" };
            yield return new object?[] { "<E", "Ἑ" };
            yield return new object?[] { "<'E", "Ἕ" };
            yield return new object?[] { "<`E", "Ἓ" };
            yield return new object?[] { ">E", "Ἐ" };
            yield return new object?[] { ">'E", "Ἔ" };
            yield return new object?[] { ">`E", "Ἒ" };
               // large eta
            yield return new object?[] { "^E", "Η" };
            yield return new object?[] { "^E|", "ῌ" };
            yield return new object?[] { "'^E", "Ή" };
            yield return new object?[] { "`^E", "Ὴ" };
            yield return new object?[] { "<^E", "Ἡ" };
            yield return new object?[] { "<^E|", "ᾙ" };
            yield return new object?[] { "<'^E", "Ἥ" };
            yield return new object?[] { "<'^E|", "ᾝ" };
            yield return new object?[] { "<`^E", "Ἣ" };
            yield return new object?[] { "<`^E|", "ᾛ" };
            yield return new object?[] { "<~^E", "Ἧ" };
            yield return new object?[] { "<~^E|", "ᾟ" };
            yield return new object?[] { ">^E", "Ἠ" };
            yield return new object?[] { ">^E|", "ᾘ" };
            yield return new object?[] { ">'^E", "Ἤ" };
            yield return new object?[] { ">'^E|", "ᾜ" };
            yield return new object?[] { ">`^E", "Ἢ" };
            yield return new object?[] { ">`^E|", "ᾚ" };
            yield return new object?[] { ">~^E", "Ἦ" };
            yield return new object?[] { ">~^E|", "ᾞ" };
            // large iota
            yield return new object?[] { "I", "Ι" };
            yield return new object?[] { "'I", "Ί" };
            yield return new object?[] { "`I", "Ὶ" };
            yield return new object?[] { "<I", "Ἱ" };
            yield return new object?[] { "<'I", "Ἵ" };
            yield return new object?[] { "<`I", "Ἳ" };
            yield return new object?[] { "<~I", "Ἷ" };
            yield return new object?[] { ">I", "Ἰ" };
            yield return new object?[] { ">'I", "Ἴ" };
            yield return new object?[] { ">`I", "Ἲ" };
            yield return new object?[] { ">~I", "Ἶ" };
            yield return new object?[] { "\"I", "Ϊ" };
            // large omicron
            yield return new object?[] { "O", "Ο" };
            yield return new object?[] { "'O", "Ό" };
            yield return new object?[] { "`O", "Ὸ" };
            yield return new object?[] { "<O", "Ὁ" };
            yield return new object?[] { "<'O", "Ὅ" };
            yield return new object?[] { "<`O", "Ὃ" };
            yield return new object?[] { ">O", "Ὀ" };
            yield return new object?[] { ">'O", "Ὄ" };
            yield return new object?[] { ">`O", "Ὂ" };
            // large upsilon
            yield return new object?[] { "U", "Υ" };
            yield return new object?[] { "'U", "Ύ" };
            yield return new object?[] { "`U", "Ὺ" };
            yield return new object?[] { "<U", "Ὑ" };
            yield return new object?[] { "<'U", "Ὕ" };
            yield return new object?[] { "<`U", "Ὓ" };
            yield return new object?[] { "<~U", "Ὗ" };
            yield return new object?[] { "\"U", "Ϋ" };
            yield return new object?[] { "Y", "Υ" };
            yield return new object?[] { "'Y", "Ύ" };
            yield return new object?[] { "`Y", "Ὺ" };
            yield return new object?[] { "<Y", "Ὑ" };
            yield return new object?[] { "<'Y", "Ὕ" };
            yield return new object?[] { "<`Y", "Ὓ" };
            yield return new object?[] { "<~Y", "Ὗ" };
            yield return new object?[] { "\"Y", "Ϋ" };
            // large omega
            yield return new object?[] { "^O", "Ω" };
            yield return new object?[] { "^O|", "ῼ" };
            yield return new object?[] { "'^O", "Ώ" };
            yield return new object?[] { "`^O", "Ὼ" };
            yield return new object?[] { "<^O", "Ὡ" };
            yield return new object?[] { "<^O|", "ᾩ" };
            yield return new object?[] { "<'^O", "Ὥ" };
            yield return new object?[] { "<'^O|", "ᾭ" };
            yield return new object?[] { "<`^O", "Ὣ" };
            yield return new object?[] { "<`^O|", "ᾫ" };
            yield return new object?[] { "<~^O", "Ὧ" };
            yield return new object?[] { "<~^O|", "ᾯ" };
            yield return new object?[] { ">^O", "Ὠ" };
            yield return new object?[] { ">^O|", "ᾨ" };
            yield return new object?[] { ">'^O", "Ὤ" };
            yield return new object?[] { ">'^O|", "ᾬ" };
            yield return new object?[] { ">`^O", "Ὢ" };
            yield return new object?[] { ">`^O|", "ᾪ" };
            yield return new object?[] { ">~^O", "Ὦ" };
            yield return new object?[] { ">~^O|", "ᾮ" };
            // large consonants
            yield return new object?[] { "B", "Β" };
            yield return new object?[] { "G", "Γ" };
            yield return new object?[] { "D", "Δ" };
            yield return new object?[] { "Th", "Θ" };
            yield return new object?[] { "K", "Κ" };
            yield return new object?[] { "L", "Λ" };
            yield return new object?[] { "M", "Μ" };
            yield return new object?[] { "N", "Ν" };
            yield return new object?[] { "NG", "ΓΓ" };
            yield return new object?[] { "NK", "ΓΚ" };
            yield return new object?[] { "NX", "ΓΞ" };
            yield return new object?[] { "NKh", "ΓΧ" };
            yield return new object?[] { "X", "Ξ" };
            yield return new object?[] { "P", "Π" };
            yield return new object?[] { "R", "Ρ" };
            yield return new object?[] { "<R", "Ῥ" };
            yield return new object?[] { "S", "Σ" };
            yield return new object?[] { "T", "Τ" }; 
            yield return new object?[] { "Ph", "Φ" };
            yield return new object?[] { "Kh", "Χ" };
            yield return new object?[] { "Ps", "Ψ" };
            // small alpha
            yield return new object?[] { "a", "α" };
            yield return new object?[] { "a|", "ᾳ" };
            yield return new object?[] { "'a", "ά" };
            yield return new object?[] { "'a|", "ᾴ" };
            yield return new object?[] { "`a", "ὰ" };
            yield return new object?[] { "`a|", "ᾲ" };
            yield return new object?[] { "~a", "ᾶ" };
            yield return new object?[] { "~a|", "ᾷ" };
            yield return new object?[] { "<a", "ἁ" };
            yield return new object?[] { "<a|", "ᾁ" };
            yield return new object?[] { "<'a", "ἅ" };
            yield return new object?[] { "<'a|", "ᾅ" };
            yield return new object?[] { "<`a", "ἃ" };
            yield return new object?[] { "<`a|", "ᾃ" };
            yield return new object?[] { "<~a", "ἇ" };
            yield return new object?[] { "<~a|", "ᾇ" };
            yield return new object?[] { ">a", "ἀ" };
            yield return new object?[] { ">a|", "ᾀ" };
            yield return new object?[] { ">'a", "ἄ" };
            yield return new object?[] { ">'a|", "ᾄ" };
            yield return new object?[] { ">`a", "ἂ" };
            yield return new object?[] { ">`a|", "ᾂ" };
            yield return new object?[] { ">~a", "ἆ" };
            yield return new object?[] { ">~a|", "ᾆ" };
            // small epsilon
            yield return new object?[] { "e", "ε" };
            yield return new object?[] { "'e", "έ" };
            yield return new object?[] { "`e", "ὲ" };
            yield return new object?[] { "<e", "ἑ" };
            yield return new object?[] { "<'e", "ἕ" };
            yield return new object?[] { "<`e", "ἓ" };
            yield return new object?[] { ">e", "ἐ" };
            yield return new object?[] { ">'e", "ἔ" };
            yield return new object?[] { ">`e", "ἒ" };
            // small eta
            yield return new object?[] { "^e", "η" };
            yield return new object?[] { "^e|", "ῃ" };
            yield return new object?[] { "'^e", "ή" };
            yield return new object?[] { "'^e|", "ῄ" };
            yield return new object?[] { "`^e", "ὴ" };
            yield return new object?[] { "`^e|", "ῂ" };
            yield return new object?[] { "~^e", "ῆ" };
            yield return new object?[] { "~^e|", "ῇ" };
            yield return new object?[] { "<^e", "ἡ" };
            yield return new object?[] { "<^e|", "ᾑ" };
            yield return new object?[] { "<'^e", "ἥ" };
            yield return new object?[] { "<'^e|", "ᾕ" };
            yield return new object?[] { "<`^e", "ἣ" };
            yield return new object?[] { "<`^e|", "ᾓ" };
            yield return new object?[] { "<~^e", "ἧ" };
            yield return new object?[] { "<~^e|", "ᾗ" };
            yield return new object?[] { ">^e", "ἠ" };
            yield return new object?[] { ">^e|", "ᾐ" };
            yield return new object?[] { ">'^e", "ἤ" };
            yield return new object?[] { ">'^e|", "ᾔ" };
            yield return new object?[] { ">`^e", "ἢ" };
            yield return new object?[] { ">`^e|", "ᾒ" };
            yield return new object?[] { ">~^e", "ἦ" };
            yield return new object?[] { ">~^e|", "ᾖ" };
            // small iota
            yield return new object?[] { "i", "ι" };
            yield return new object?[] { "'i", "ί" };
            yield return new object?[] { "`i", "ὶ" };
            yield return new object?[] { "~i", "ῖ" };
            yield return new object?[] { "<i", "ἱ" };
            yield return new object?[] { "<'i", "ἵ" };
            yield return new object?[] { "<`i", "ἳ" };
            yield return new object?[] { "<~i", "ἷ" };
            yield return new object?[] { ">i", "ἰ" };
            yield return new object?[] { ">'i", "ἴ" };
            yield return new object?[] { ">`i", "ἲ" };
            yield return new object?[] { ">~i", "ἶ" };
            yield return new object?[] { "\"i", "ϊ" };
            yield return new object?[] { "\"'i", "ΐ" };
            yield return new object?[] { "\"`i", "ῒ" };
            yield return new object?[] { "\"~i", "ῗ" };
            // small omicron
            yield return new object?[] { "o", "ο" };
            yield return new object?[] { "'o", "ό" };
            yield return new object?[] { "`o", "ὸ" };
            yield return new object?[] { "<o", "ὁ" };
            yield return new object?[] { "<'o", "ὅ" };
            yield return new object?[] { "<`o", "ὃ" };
            yield return new object?[] { ">o", "ὀ" };
            yield return new object?[] { ">'o", "ὄ" };
            yield return new object?[] { ">`o", "ὂ" };
            // small upsilon
            yield return new object?[] { "u", "υ" };
            yield return new object?[] { "'u", "ύ" };
            yield return new object?[] { "`u", "ὺ" };
            yield return new object?[] { "~u", "ῦ" };
            yield return new object?[] { "<u", "ὑ" };
            yield return new object?[] { "<'u", "ὕ" };
            yield return new object?[] { "<`u", "ὓ" };
            yield return new object?[] { "<~u", "ὗ" };
            yield return new object?[] { ">u", "ὐ" };
            yield return new object?[] { ">'u", "ὔ" };
            yield return new object?[] { ">`u", "ὒ" };
            yield return new object?[] { ">~u", "ὖ" };
            yield return new object?[] { "\"u", "ϋ" };
            yield return new object?[] { "\"'u", "ΰ" };
            yield return new object?[] { "\"`u", "ῢ" };
            yield return new object?[] { "\"~u", "ῧ" };
            yield return new object?[] { "y", "υ" };
            yield return new object?[] { "'y", "ύ" };
            yield return new object?[] { "`y", "ὺ" };
            yield return new object?[] { "~y", "ῦ" };
            yield return new object?[] { "<y", "ὑ" };
            yield return new object?[] { "<'y", "ὕ" };
            yield return new object?[] { "<`y", "ὓ" };
            yield return new object?[] { "<~y", "ὗ" };
            yield return new object?[] { ">y", "ὐ" };
            yield return new object?[] { ">'y", "ὔ" };
            yield return new object?[] { ">`y", "ὒ" };
            yield return new object?[] { ">~y", "ὖ" };
            yield return new object?[] { "\"y", "ϋ" };
            yield return new object?[] { "\"'y", "ΰ" };
            yield return new object?[] { "\"`y", "ῢ" };
            yield return new object?[] { "\"~y", "ῧ" };
            // small omega
            yield return new object?[] { "^o", "ω" };
            yield return new object?[] { "^o|", "ῳ" };
            yield return new object?[] { "'^o", "ώ" };
            yield return new object?[] { "'^o|", "ῴ" };
            yield return new object?[] { "`^o", "ὼ" };
            yield return new object?[] { "`^o|", "ῲ" };
            yield return new object?[] { "~^o", "ῶ" };
            yield return new object?[] { "~^o|", "ῷ" };
            yield return new object?[] { "<^o", "ὡ" };
            yield return new object?[] { "<^o|", "ᾡ" };
            yield return new object?[] { "<'^o", "ὥ" };
            yield return new object?[] { "<'^o|", "ᾥ" };
            yield return new object?[] { "<`^o", "ὣ" };
            yield return new object?[] { "<`^o|", "ᾣ" };
            yield return new object?[] { "<~^o", "ὧ" };
            yield return new object?[] { "<~^o|", "ᾧ" };
            yield return new object?[] { ">^o", "ὠ" };
            yield return new object?[] { ">^o|", "ᾠ" };
            yield return new object?[] { ">'^o", "ὤ" };
            yield return new object?[] { ">'^o|", "ᾤ" };
            yield return new object?[] { ">`^o", "ὢ" };
            yield return new object?[] { ">`^o|", "ᾢ" };
            yield return new object?[] { ">~^o", "ὦ" };
            yield return new object?[] { ">~^o|", "ᾦ" };
            // small consonant
            yield return new object?[] { "b", "β" };
            yield return new object?[] { "g", "γ" };
            yield return new object?[] { "d", "δ" };
            yield return new object?[] { "z", "ζ" };
            yield return new object?[] { "th", "θ" };
            yield return new object?[] { "k", "κ" };
            yield return new object?[] { "l", "λ" };
            yield return new object?[] { "m", "μ" };
            yield return new object?[] { "n", "ν" };
            yield return new object?[] { "ng", "γγ" };
            yield return new object?[] { "nk", "γκ" };
            yield return new object?[] { "nx", "γξ" };
            yield return new object?[] { "nkh", "γχ" };
            yield return new object?[] { "x", "ξ" };
            yield return new object?[] { "p", "π" };
            yield return new object?[] { "s", "ς" };
            yield return new object?[] { "sa", "σα" };
            yield return new object?[] { "ssa", "σσα" };
            yield return new object?[] { "c", "σ" };
            yield return new object?[] { "t", "τ" };
            yield return new object?[] { "ph", "φ" };
            yield return new object?[] { "kh", "χ" };
            yield return new object?[] { "ps", "ψ" };
            // punctuation
            yield return new object?[] { ",", "," };
            yield return new object?[] { ";", "·" };
            yield return new object?[] { ".", "." };
            yield return new object?[] { "?", ";" };
            yield return new object?[] { "d'", "δ'" };
            // white space
            yield return new object?[] { " ", " " };
            yield return new object?[] { "\t", "\t" };
            yield return new object?[] { "\n", "\n" };
            yield return new object?[] { "\r\n", "\r\n" };
            // other symbols
            yield return new object?[] { "-", "-" };
            yield return new object?[] { "(", "(" };
            yield return new object?[] { ")", ")" };
            yield return new object?[] { "[", "[" };
            yield return new object?[] { "]", "]" };
            yield return new object?[] { "<", "<" };
            yield return new object?[] { ">", ">" };
            // multi-byte character
            yield return new object?[] { "あ", "あ" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}