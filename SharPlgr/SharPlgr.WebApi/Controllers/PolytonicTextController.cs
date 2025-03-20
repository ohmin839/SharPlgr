using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SharPlgr.Api;

namespace SharPlgr.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PolytonicTextController : ControllerBase
{
    private readonly ILogger<PolytonicTextController> _logger;

    public PolytonicTextController(ILogger<PolytonicTextController> logger)
    {
        _logger = logger;
    }

    [Route("Converted/String")]
    [HttpPost]
    public string ConvertToPolytonicText([FromBody]string text)
    {
        string converted = SharPlgrApi.ConvertToPolytonicText(text);
        return converted;
    }

    [Route("Converted/File")]
    [HttpPost]
    public async Task<IActionResult> ConvertToPolytonicText(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        var tempFilePath = Path.GetTempFileName();
        try
        {
            using (var reader = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
            using (var writer = System.IO.File.AppendText(tempFilePath))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var converted = SharPlgrApi.ConvertToPolytonicText(line);
                    await writer.WriteLineAsync(converted);
                }
            }
            var fileBytes = await System.IO.File.ReadAllBytesAsync(tempFilePath);
            return File(fileBytes, MediaTypeNames.Text.Plain, $"polytonic_{file.FileName}");
        }
        finally
        {
            System.IO.File.Delete(tempFilePath);
        }
    }
}
