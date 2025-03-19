using static SharPlgr.Api.SharPlgrApi;
using System.Management.Automation;

namespace SharPlgr.Cmdlet;

[Cmdlet(VerbsCommon.Get, "PolytonicWords")]
[Alias("sharplgrcoll")]
public class Collectormdlet : System.Management.Automation.Cmdlet
{
    private SortedSet<string> allWords = new();

    [Parameter(
        Position = 0,
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true)]
    public string[]? Lines
    {
        get; set;
    }

    protected override void ProcessRecord()
    {
        if (Lines != null && Lines.Length > 0)
        {
            foreach (var line in Lines)
            {
                var words = CollectPolytonicWords(line);
                foreach (var word in words)
                {
                    if (!allWords.Contains(word))
                    {
                        WriteObject(word);
                        allWords.Add(word);
                    }
                }
            }
        }
    }

    protected override void EndProcessing()
    {
        allWords.Clear();
    }
}