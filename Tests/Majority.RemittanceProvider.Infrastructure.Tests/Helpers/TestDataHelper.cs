using System;
using System.Collections.Generic;
using Majority.RemittanceProvider.Domain.RemittanceProvider;

namespace Majority.RemittanceProvider.Infrastructure.Tests.Helpers
{
    public static class TestDataHelper
    {
        public static Country Country(bool isActive = true)
        {
            return new Country
            {
                Code = "US",
                Name = "United State of America",
                IsActive = isActive,
                CurrencyCode = "USD"
            };
        }

        public static Transaction Transaction(Guid transactionId) =>

            new Transaction
            {
                TransactionId = transactionId,
                ExchangeRate = 0.0,
                Currency = "USD",
                FromAmount = 50,
                TransactionNumber = "12345678",
                Status = TransactionStatus.Pending,
                Fees = 3,
                TransactionSender = new TransactionSender
                {
                    SenderFirstName = "Jansi Rajkumar",
                    SenderLastName = "Thangapandi",
                    SenderEmail = "XXX@gmail.com",
                    SenderPhoneNumber = "XXX",
                    Address = "XXX 54",
                    SenderCountry = "SE",
                    SenderCity = "Stockholm",
                    SenderFromState = "TE",
                    SenderPostalCode = "12373",
                    DateOfBirth = new DateTime(1981, 03, 07),
                    TransactionId = transactionId
                },
                TransactionTo = new TransactionTo
                {
                    ToFirstName = "Sharmila",
                    ToLastName = "Jansi Rajkumar",
                    ToCountry = "IN",
                    ToBankAccountName = "Sharmila jansi rajkumar",
                    ToBankAccountNumber = "12345678",
                    ToBankName = "HDFC",
                    ToBankCode = "HDFC",
                    TransactionId = transactionId
                }
            };
        public static Bank Bank =>
            new Bank
            {
                AccountNumber = "12345578",
                BankName = "HSBC Bank of America",
                BankCode = "HSB",
                IFSCCode = "431011201",
                MICRCode = "43101120",
                CountryCode = "US",
            };
        public static ExchangeRate ExchangeRate =>
            new ExchangeRate
            {
                BaseCurrencyCode = "USD",
                DestinationCurrencyCode = "AUD",
                IsActive = true,
                ExchangeRateDate = new DateTime(2022, 01, 01),
                Rate = 1.452348,
                ExchangeRateToken = "ExchangeToken"
            };
        public static ExchangeRate ExchangeRateInActive =>
           new ExchangeRate
           {
               BaseCurrencyCode = "USD",
               DestinationCurrencyCode = "AUD",
               IsActive = false,
               ExchangeRateDate = DateTime.UtcNow,
               Rate = 1.452348,
               ExchangeRateToken = Guid.NewGuid().ToString()
           };

        public static List<State> States =>
            new List<State>
            { new State
            {
                Code = "CA",
                Name = "California",
                CountryCode = "US",
            },
            new State
            {
                Code = "TE",
                Name = "Texas",
                CountryCode = "US",
            }};
        public static Beneficiary Beneficiary =>
            new Beneficiary
            {
                AccountNumber = "123456789",
                BankCode = "BOA",
                BeneficiaryName = "Rajkumar"

            };
        public static FeesDetails FeesDetails =>
            new FeesDetails
            {
                FeesDetailsId = 1,
                FeesPercentage = 0.6,
                IsAvailable = true,
                FromCountryCode = "US",
                ToCountryCode = "SE",
                TransferModeId = 1,
            };
        public static TransferMode TransferMode =>
            new TransferMode
            {
                TransferModeId = 1,
                TransferModeDescription = "Transfer money from bank",
                TransferModeName = "Bank",
            };
    }
}
