using System.ComponentModel.DataAnnotations;
using Majority.RemittanceProvider.Application.Features.Dtos;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Commands;
public class TransactionCommand : IRequest<TransactionStatusDto>
{
    [Required(ErrorMessage = "Sender firstname is mandatory")]
    public string SenderFirstName { get; set; }

    [Required(ErrorMessage = "Sender last name is mandatory")]
    public string SenderLastName { get; set; }

    [Required(ErrorMessage = "Sender E-mail is mandatory")]
    public string SenderEmail { get; set; }

    [Required(ErrorMessage = "Sender phone number is mandatory")]
    public string SenderPhoneNumber { get; set; }

    [Required(ErrorMessage = "Sender address is mandatory")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Sender country is mandatory")]
    public string SenderCountry { get; set; }

    [Required(ErrorMessage = "Sender city is mandatory")]
    public string SenderCity { get; set; }

    [Required(ErrorMessage = "Sender from state is mandatory")]
    public string SenderFromState { get; set; }

    [Required(ErrorMessage = "Sender postal code is mandatory")]
    public string SenderPostalCode { get; set; }

    [Required(ErrorMessage = "Date of birth is mandatory")]
    [DisplayFormat(DataFormatString = "YYYY-MM-DD")]
    public string DateOfBirth { get; set; }

    [Required(ErrorMessage = "To first name is mandatory")]
    public string ToFirstName { get; set; }

    [Required(ErrorMessage = "To first last name is mandatory")]
    public string ToLastName { get; set; }

    [Required(ErrorMessage = "To country is mandatory")]
    public string ToCountry { get; set; }

    [Required(ErrorMessage = "To bank account name is mandatory")]
    public string ToBankAccountName { get; set; }

    [Required(ErrorMessage = "To bank account number is mandatory")]
    public string ToBankAccountNumber { get; set; }

    [Required(ErrorMessage = "To bank name is mandatory")]
    public string ToBankName { get; set; }

    [Required(ErrorMessage = "To bank code is mandatory")]
    public string ToBankCode { get; set; }

    [Required(ErrorMessage = "From amount is mandatory")]
    public double FromAmount { get; set; }

    [Required(ErrorMessage = "Exchange rate is mandatory")]
    public double ExchangeRate { get; set; }

    [Required(ErrorMessage = "Fees is mandatory")]
    public double Fees { get; set; }

    [Required(ErrorMessage = "Transaction number is mandatory")]
    public string TransactionNumber { get; set; }

    [Required(ErrorMessage = "Currency is mandatory")]
    public string FromCurrency { get; set; }


}

