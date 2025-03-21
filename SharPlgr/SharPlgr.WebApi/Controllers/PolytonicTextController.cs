using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharPlgr.Api;
using SharPlgr.WebApi.Models;

namespace SharPlgr.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PolytonicTextController : ControllerBase
{
    private readonly ILogger<PolytonicTextController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public PolytonicTextController(
        ILogger<PolytonicTextController> logger,
        ApplicationDbContext dbContext
        )
    {
        _logger = logger;
        _dbContext = dbContext;
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

    [Route("NewRawWords/File")]
    [HttpPost]
    public async Task<IActionResult> ExtractPolytonicWords(IFormFile file)
    {
        int newRawWords = 0;
        using (var reader = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
        using (var tran = await _dbContext.Database.BeginTransactionAsync())
        {
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                var words = SharPlgrApi.CollectPolytonicWords(line);
                foreach(var word in words)
                {
                    try
                    {
                        bool exists = await _dbContext.RawWords.AnyAsync(e => e.Word == word);
                        if (!exists)
                        {
                            await _dbContext.AddAsync(new TRawWord{Word = word});
                            await _dbContext.SaveChangesAsync();
                            newRawWords++;
                        }
                    }
                    catch
                    {
                        await _dbContext.Database.RollbackTransactionAsync();
                        throw;
                    }
                }
            }
            await _dbContext.Database.CommitTransactionAsync();
        }
        return Ok(new {
            newRowWords = newRawWords
        });
    }
}
