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

    [Route("Converted")]
    [HttpPost]
    public string ConvertToPolytonicText([FromBody]string text)
    {
        string converted = SharPlgrApi.ConvertToPolytonicText(text);
        return converted;
    }
}
