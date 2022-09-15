using System.Text.RegularExpressions;
using FluentValidation;
using Majority.RemittanceProvider.Application.Features.Commands;


namespace Majority.RemittanceProvider.Application.Features.Validators
{
    public class TransactionCommandValidator : AbstractValidator<TransactionCommand>
    {
        public TransactionCommandValidator()
        {
            RuleFor(transactionCommand => transactionCommand.SenderFromState).Length(2).WithMessage("Send from state code is not valid");
            RuleFor(transactionCommand => transactionCommand.DateOfBirth).Must(DateTimeValidator)
                .WithMessage("Date of birth format should be YYYY-MM-DD");
            RuleFor(transactionCommand => transactionCommand.SenderCountry).Must(IsoAlphaTwoValidator.IsoAlphaValidator)
                .WithMessage("Sender country is not valid");
            RuleFor(transactionCommand => transactionCommand.ToCountry).Must(IsoAlphaTwoValidator.IsoAlphaValidator)
                .WithMessage("To country is not valid");
            RuleFor(transactionCommand => transactionCommand.TransactionNumber).Must(x => x.Length >= 10 && x.Length < 25)
                .WithMessage("Transaction number is not valid");
            RuleFor(transactionCommand => transactionCommand.FromCurrency)
                .Must(x => ISO._4217.CurrencyCodesResolver.Codes.Any(c => c.Code == x))
                .WithMessage("From currency code is not valid");
        }

        public static bool DateTimeValidator(string dateOfBirth)
        {
            Regex dateFormatRegex =
                new("^[0-9]{4}-(((0[13578]|(10|12))-(0[1-9]|[1-2][0-9]|3[0-1]))|(02-(0[1-9]|[1-2][0-9]))|((0[469]|11)-(0[1-9]|[1-2][0-9]|30)))$");
            return dateFormatRegex.IsMatch(dateOfBirth);
        }


    }
}
