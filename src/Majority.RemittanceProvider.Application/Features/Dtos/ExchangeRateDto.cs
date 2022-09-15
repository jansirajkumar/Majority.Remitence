namespace Majority.RemittanceProvider.Application.Features.Dtos;

public class ExchangeRateDto
{
    public string? SourceCurrencyCode { get; set; }
    public string? DestinationCurrencyCode { get; set; }
    public double ExchangeRate { get; set; }
    public string? ExchangeRateToken { get; set; }
}

