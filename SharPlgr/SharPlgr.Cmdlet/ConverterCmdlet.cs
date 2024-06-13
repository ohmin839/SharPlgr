using static SharPlgr.Api.SharPlgrApi;
using System.Management.Automation;

namespace SharPlgr.Cmdlet;

[Cmdlet(VerbsData.ConvertTo, "PolytonicText")]
[Alias("sharplgrconv")]
public class ConverterCmdlet : System.Management.Automation.Cmdlet
{
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
                WriteObject(ConvertToPolytonicText(line));
            }
        }
    }
}