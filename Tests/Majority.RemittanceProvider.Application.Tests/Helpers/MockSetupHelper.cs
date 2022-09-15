using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Moq;

namespace Majority.RemittanceProvider.Application.Tests.Helpers
{
    public static class MockSetupHelper
    {
        public static Mock<ICountryRepository> MockCountryRepository()
        {
            Mock<ICountryRepository> _mockRepository = new();
            _mockRepository.Setup(x => x.GetSupportedCountries(It.IsAny<bool>()))
               .Returns(Task.FromResult(new System.Collections.Generic.List<Country>
           {
                new Country
                {
                    Name ="United States Of America",
                    Code ="US",
                    CurrencyCode = "USD"
                }
           }));
            return _mockRepository;
        }
        public static Mock<IFeesRepository> MockFeesRepository()
        {
            Mock<IFeesRepository> _mockRepository = new();
            _mockRepository.Setup(x => x.GetFees(It.IsAny<string>(), It.IsAny<string>()))
               .Returns(Task.FromResult(new List<FeesDetails>
           {
                   new FeesDetails
                    {
                        FeesDetailsId = 1,
                        FeesPercentage = 0.6,
                        IsAvailable = true,
                        FromCountryCode = "US",
                        ToCountryCode = "SE",
                        TransferModeId = 1,
                        TransferMode = new TransferMode
                        {
                            TransferModeId = 1,
                            TransferModeDescription = "Transfer money from bank",
                            TransferModeName ="Bank",
                        }
                    },
           }));
            return _mockRepository;
        }
        public static Mock<IStateRepository> MockStateRepository()
        {
            Mock<IStateRepository> _mockRepository = new();
            _mockRepository.Setup(x => x.GetStates(It.IsAny<string>()))
               .Returns(Task.FromResult(new List<State>
           {
                new State
                {
                    Code ="CA",
                    Name = "California"
                }
           }));
            return _mockRepository;
        }

        public static Mock<IBankRepository> MockBankRepository()
        {
            Mock<IBankRepository> _mockRepository = new();
            _mockRepository.Setup(x => x.GetBankDetailsByCountryCode(It.IsAny<string>()))
               .Returns(Task.FromResult(new System.Collections.Generic.List<Bank>
           {
                new Bank
                {
                    AccountNumber = "12345578",
                BankName = "HSBC Bank of America",
                BankCode = "HSB",
                IFSCCode = "431011201",
                MICRCode = "43101120",
                CountryCode = "US",
                }
           }));
            return _mockRepository;
        }
        public static Mock<IBeneficiaryRepository> MockBeneficieryRepository()
        {
            Mock<IBeneficiaryRepository> _mockRepository = new();
            _mockRepository.Setup(x => x.GetBeneficiaryDetailsByBankCodeAndAccountNumber(It.IsAny<string>(), It.IsAny<string>()))
               .Returns(Task.FromResult(new Beneficiary
               {

                   AccountNumber = "123456789",
                   BankCode = "BOA",
                   BeneficiaryName = "Rajkumar"
               }
           ));
            return _mockRepository;
        }
        public static Mock<ITransactionRepository> MockTransactionRepository(Guid transactionId)
        {
            Mock<ITransactionRepository> _mockRepository = new();
            Transaction? transaction = new Transaction();
            _mockRepository.Setup(x => x.GetTransaction(It.IsAny<Guid>()))
               .Returns(Task.FromResult<Transaction?>(new Transaction
               {
                   TransactionId = transactionId,
                   Status = TransactionStatus.Completed,
               }
           ));
            return _mockRepository;
        }
        public static Mock<IExchangeRateRepository> MockExchangeateRepository()
        {
            Mock<IExchangeRateRepository> _mockRepository = new Mock<IExchangeRateRepository>();
            _mockRepository.Setup(x => x.GetExchangeRate(It.IsAny<List<string>>()))
               .Returns(Task.FromResult(new List<ExchangeRate>
           {new ExchangeRate
                {
                BaseCurrencyCode = "USD",
                DestinationCurrencyCode = "AUD",
                IsActive = true,
                ExchangeRateDate = DateTime.UtcNow,
                Rate = 1.452348,
                ExchangeRateToken = "ExchangeToken"
            },
            new ExchangeRate
            {
                BaseCurrencyCode = "USD",
                DestinationCurrencyCode = "USD",
                IsActive = true,
                ExchangeRateDate = DateTime.UtcNow,
                Rate = 1,
                ExchangeRateToken ="ExchangeToken"
            },
             new ExchangeRate
             {
                 BaseCurrencyCode = "USD",
                 DestinationCurrencyCode = "SEK",
                 IsActive = true,
                 ExchangeRateDate = DateTime.UtcNow,
                 Rate = 10.45648,
                 ExchangeRateToken = "ExchangeToken"
             }
           }));
            return _mockRepository;
        }
    }
}
