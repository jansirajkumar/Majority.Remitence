using Majority.RemittanceProvider.Application.Features.Dtos;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Queries;
public class GetExchangeRatesQuery : IRequest<List<ExchangeRateDto>>
{
    public string From { get; set; }

    public string To { get; set; }

    public GetExchangeRatesQuery(string from, string to)
    {
        From = string.IsNullOrWhiteSpace(from) ? "USD" : from;
        To = to;
    }
}

