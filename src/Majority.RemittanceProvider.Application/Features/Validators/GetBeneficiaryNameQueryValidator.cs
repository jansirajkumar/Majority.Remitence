using FluentValidation;
using Majority.RemittanceProvider.Application.Features.Queries;

namespace Majority.RemittanceProvider.Application.Features.Validators
{
    internal class GetBeneficiaryNameQueryValidator : AbstractValidator<GetBeneficiaryNameQuery>
    {
        public GetBeneficiaryNameQueryValidator()
        {
            RuleFor(getBenerificiaryNameQuery => getBenerificiaryNameQuery.AccountNumber).NotEmpty().WithMessage("Account number is mandatory");
            RuleFor(getBenerificiaryNameQuery => getBenerificiaryNameQuery.BankCode).NotEmpty().WithMessage("Bank code is mandatory");
        }
    }
}
