using FluentValidation;
using Majority.RemittanceProvider.Application.Features.Queries;

namespace Majority.RemittanceProvider.Application.Features.Validators
{
    public class ExchangeRateQueryValidator : AbstractValidator<GetExchangeRatesQuery>
    {
        public ExchangeRateQueryValidator()
        {
            RuleFor(exchangeRateQuery => exchangeRateQuery.From).Length(3).WithMessage("Source currency code is not valid");
            RuleFor(exchangeRateQuery => exchangeRateQuery.From).NotEmpty().WithMessage("Destination currency code should not be empty");
        }
    }
}
