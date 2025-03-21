using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharPlgr.WebApi.Models;

public class TRawWord
{
    public int Id { get; set; }

    public required string Word { get; set; }
}