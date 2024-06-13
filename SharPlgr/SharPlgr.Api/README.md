# SharPlgr.Api
`SharPlgr.Api` provides some APIs as static methods.

## Conversion API
`ConvertToPolytonicText` method converts an ASCII string into a string in polytonic Greek.
```c#
using static SharPlgr.Api.SharPlgrApi;

string converted = ConvertToPolytonicText(">'anthr^opos");
Console.WriteLine(converted); // ἄνθρωπος
```

## Collection API
`CollectPolytonicWords` method splits a text in polytonic Greek into words:
```c#
using System.Collections;
using static SharPlgr.Api.SharPlgrApi;

string converted = ConvertToPolytonicText("ὁ ἄνθρωπός τις");
List<string> split = CollectPolytonicWords(converted);
Console.WriteLine($"[{string.Join(", ", split)}]"); // [ὁ, ἄνθρωπός, τις]
```

## Conversion Rules
(Under construction)