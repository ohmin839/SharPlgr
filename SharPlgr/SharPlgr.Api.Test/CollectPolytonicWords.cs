using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Xunit;
using static SharPlgr.Api.SharPlgrApi;

namespace SharPlgr.Api.Test;

 public class CollectPolytonicWordsTests
{
    [Theory]
    [ClassData(typeof(TestData))]
    public void TestMethod(string argument, List<string> expected)
    {
        var actual = CollectPolytonicWords(argument);
        Assert.Equal(expected, actual);
    }
    
    class TestData : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator()
        {
            yield return new object?[] { null, new List<string>(0) };
            yield return new object?[] { "", new List<string>(0) };
            yield return new object?[] { "α", new List<string> { "α" } };
            yield return new object?[] { "δ'", new List<string>() { "δ'" } };
            yield return new object?[] { "ὁ ἄνθρωπός τις", new List<string>() { "ὁ", "ἄνθρωπός", "τις" } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}