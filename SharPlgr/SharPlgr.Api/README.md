# SharPlgr.Api
`SharPlgr.Api` provides some APIs as static methods.

- `ConvertToPolytonicText` method converts an ASCII string into a string in polytonic Greek.
- `CollectPolytonicWords` method splits a text in polytonic Greek into words:

```c#
using System.Collections;
using static SharPlgr.Api.SharPlgrApi;

string converted = ConvertToPolytonicText("ὁ ἄνθρωπός τις");
Console.WriteLine(converted); // ὁ ἄνθρωπός τις

List<string> split = CollectPolytonicWords(converted);
Console.WriteLine($"[{string.Join(", ", split)}]"); // [ὁ, ἄνθρωπός, τις]
```
