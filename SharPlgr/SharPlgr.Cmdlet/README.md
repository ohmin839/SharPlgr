# SharPlgr.Cmdlet
`SharPlgr.Cmdlet` provides some cmdlets for PowerShell.

## ConvertTo-PolytonicText
The cmdlet `ConvertTo-PolytonicText`(`sharplgrconv` for short)
converts ASCII strings into strings in polytonic Greek.
```powershell
PS> ConvertTo-PolytonicText ">'anthr^opos"
ἄνθρωπός

PS> Get-Content ./Alpha.txt -TotalCount 1 | ConvertTo-PolytonicText
Πάντες ἄνθρωποι τοῦ εἰδέναι ὀρέγονται φύσει. σημεῖον δ'
```

## Get-PolytonicWords
The cmdlet `Get-PolytonicWords`(`sharplgrcoll` for short)
extracts words uniquely from texts in polytonic Greek.
```powershell
PS> ConvertTo-PolytonicText "<o >'anthr^op'os tis" | Get-PolytonicWords
ὁ
ἄνθρωπός
τις

PS> Get-Content ./Alpha.txt -TotalCount 1 | ConvertTo-PolytonicText | Get-PolytonicWords 
Πάντες
ἄνθρωποι
τοῦ
εἰδέναι
ὀρέγονται
φύσει
σημεῖον
δ'
```

## Installation
First, build `SharPlgr.Cmdlet`.
```bash
$ cd SharPlgr/SharPlgr.Cmdlet
$ dotnet build
```

Then, launch Powershell and run `Import-Module`. That's it.
```bash
$ pwsh
```
```powershell
PS> cd bin/Debug/net8.0
PS> Import-Module ./SharPlgr.Cmdlet.psd1
```