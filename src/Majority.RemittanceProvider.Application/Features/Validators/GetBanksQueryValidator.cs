using FluentValidation;
using Majority.RemittanceProvider.Application.Features.Queries;

namespace Majority.RemittanceProvider.Application.Features.Validators
{
    public class GetBanksQueryValidator : AbstractValidator<GetBanksQuery>
    {
        public GetBanksQueryValidator()
        {
            RuleFor(getBanksQuery => getBanksQuery.CountryCode).Must(IsoAlphaTwoValidator.IsoAlphaValidator)
                .WithMessage("Country code is not valid");
        }

    }
}
