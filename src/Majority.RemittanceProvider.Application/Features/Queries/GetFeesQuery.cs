using Majority.RemittanceProvider.Application.Features.Dtos;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Queries
{
    public class GetFeesQuery : IRequest<FeesDto>
    {
        public string From { get; set; }
        public string To { get; set; }
        public GetFeesQuery(string to, string from = "US")
        {
            From = from;
            To = to;
        }
    }
}
