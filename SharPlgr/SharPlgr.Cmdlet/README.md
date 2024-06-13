# SharPlgr.Cmdlet
`SharPlgr.Cmdlet` provides some cmdlets for PowerShell.

## ConvertTo-PolytonicText
The cmdlet `ConvertTo-PolytonicText`(`sharplgrconv` for short)
converts ASCII strings into strings in polytonic Greek.
```powershell
PS> ConvertTo-PolytonicText ">'anthr^opos"
ἄνθρωπός

PS> Get-Content ./alpha.txt | ConvertTo-PolytonicText
Πάντες ἄνθρωποι τοῦ εἰδέναι ὀρέγονται φύσει. σημεῖον δ'
...
```

## Get-PolytonicWords
The cmdlet `CollectPolytonicWords`(`sharplgrcoll` for short)
splits texts in polytonic Greek into words:
```powershell
PS> ConvertTo-PolytonicText "<o >'anthr^op'os tis" | Get-PolytonicWords
ὁ
ἄνθρωπός
τις

PS> Get-Content ./alpha.txt | ConvertTo-PolytonicText | Get-PolytonicWords 
Πάντες
ἄνθρωποι
τοῦ
εἰδέναι
ὀρέγονται
φύσει
σημεῖον
δ'
...
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
PS> Import-Module bin/Debug/net8.0/SharPlgr.Cmdlet.psd1
```