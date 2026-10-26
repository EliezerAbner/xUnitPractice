using System.ComponentModel.DataAnnotations;
using ServiceContracts.CustomValidators;

namespace ServiceContracts.DTO;

public class SellOrderRequest
{
    [Required]
    public string? StockSymbol { get; set; }

    [Required]
    public string? StockName { get; set; }

    [MaximumDateValidator]
    public DateTime DateAndTimeOfOrder { get; set; }

    [Range(1, 100000)]
    public uint Quantity { get; set; }

    [Range(1, 100000)]
    public double Price { get; set; }
}