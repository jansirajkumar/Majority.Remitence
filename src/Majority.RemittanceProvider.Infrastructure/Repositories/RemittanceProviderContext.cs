using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Majority.RemittanceProvider.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Majority.RemittanceProvider.Infrastructure.Repositories;

public class RemittanceProviderContext : DbContext
{
    private readonly IMediator _mediator;
    public RemittanceProviderContext(DbContextOptions<RemittanceProviderContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public async Task<int> CommitAsync()
    {
        await _mediator.DispatchEventsAsync(this);
        return await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // define keys
        modelBuilder.Entity<Country>().HasKey(x => new { x.Code });
        modelBuilder.Entity<State>().HasKey(x => new { x.Code, x.CountryCode });
        modelBuilder.Entity<Currency>().HasKey(x => new { x.Code });
        modelBuilder.Entity<ExchangeRate>().HasKey(x => new { x.BaseCurrencyCode, x.DestinationCurrencyCode, x.IsActive });
        modelBuilder.Entity<TransactionSender>().HasKey(x => new { x.TransactionId });
        modelBuilder.Entity<TransactionTo>().HasKey(x => new { x.TransactionId });
        modelBuilder.Entity<Bank>().HasKey(x => new { x.BankCode, x.CountryCode });
        modelBuilder.Entity<Beneficiary>().HasKey(x => new { x.AccountNumber, x.BankCode });


        modelBuilder.Entity<State>()
            .HasOne(p => p.Country)
            .WithMany(b => b.States);

        modelBuilder.Entity<Bank>()
            .HasOne(p => p.Country)
            .WithMany(p => p.Banks);

        modelBuilder.Entity<FeesDetails>()
            .HasOne(p => p.TransferMode)
            .WithMany(b => b.Fees);

        modelBuilder.Entity<Transaction>()
            .HasOne(a => a.TransactionSender);


        modelBuilder.Entity<Transaction>()
            .HasOne(a => a.TransactionTo);


        // Define Data

        _ = modelBuilder.Entity<Currency>()
            .HasData(new Currency
            {
                Code = "USD",
                CountryCode = "US",
                Name = "US dollar"

            }, new Currency
            {
                Code = "SEK",
                CountryCode = "SE",
                Name = "Swedish Krona"

            }, new Currency
            {
                Code = "NOK",
                CountryCode = "NO",
                Name = "Norwegin Krona"

            }, new Currency
            {
                Code = "PKR",
                CountryCode = "PK",
                Name = "Pakistan rupee"

            }, new Currency
            {
                Code = "AUD",
                CountryCode = "AU",
                Name = "Australian Dollar"

            }, new Currency
            {
                Code = "SGD",
                CountryCode = "SG",
                Name = "Singapore Dollar"

            }, new Currency
            {
                Code = "INR",
                CountryCode = "IN",
                Name = "Indian Rupee"

            }, new Currency
            {
                Code = "GBP",
                CountryCode = "UK",
                Name = "Pound sterling"

            });

        _ = modelBuilder.Entity<ExchangeRate>()
            .HasData(new ExchangeRate
            {
                BaseCurrencyCode = "USD",
                DestinationCurrencyCode = "AUD",
                IsActive = true,
                ExchangeRateDate = DateTime.UtcNow,
                Rate = 1.452348,
                ExchangeRateToken = Guid.NewGuid().ToString()
            },
            new ExchangeRate
            {
                BaseCurrencyCode = "USD",
                DestinationCurrencyCode = "USD",
                IsActive = true,
                ExchangeRateDate = DateTime.UtcNow,
                Rate = 1,
                ExchangeRateToken = Guid.NewGuid().ToString()
            },
             new ExchangeRate
             {
                 BaseCurrencyCode = "USD",
                 DestinationCurrencyCode = "SEK",
                 IsActive = true,
                 ExchangeRateDate = DateTime.UtcNow,
                 Rate = 10.45648,
                 ExchangeRateToken = Guid.NewGuid().ToString()
             },
             new ExchangeRate
             {
                 BaseCurrencyCode = "USD",
                 DestinationCurrencyCode = "INR",
                 IsActive = true,
                 ExchangeRateDate = DateTime.UtcNow,
                 Rate = 79.14225,
                 ExchangeRateToken = Guid.NewGuid().ToString()
             },
             new ExchangeRate
             {
                 BaseCurrencyCode = "USD",
                 DestinationCurrencyCode = "EUR",
                 IsActive = true,
                 ExchangeRateDate = DateTime.UtcNow,
                 Rate = 0.985505,
                 ExchangeRateToken = Guid.NewGuid().ToString()
             },
             new ExchangeRate
             {
                 BaseCurrencyCode = "USD",
                 DestinationCurrencyCode = "GBP",
                 IsActive = true,
                 ExchangeRateDate = DateTime.UtcNow,
                 Rate = 0.853265,
                 ExchangeRateToken = Guid.NewGuid().ToString()
             },
             new ExchangeRate
             {
                 BaseCurrencyCode = "USD",
                 DestinationCurrencyCode = "NOK",
                 IsActive = true,
                 ExchangeRateDate = DateTime.UtcNow,
                 Rate = 9.818801,
                 ExchangeRateToken = Guid.NewGuid().ToString()
             },
             new ExchangeRate
             {
                 BaseCurrencyCode = "USD",
                 DestinationCurrencyCode = "DKK",
                 IsActive = true,
                 ExchangeRateDate = DateTime.UtcNow,
                 Rate = 7.32869,
                 ExchangeRateToken = Guid.NewGuid().ToString()
             },
             new ExchangeRate
             {
                 BaseCurrencyCode = "USD",
                 DestinationCurrencyCode = "PKR",
                 IsActive = true,
                 ExchangeRateDate = DateTime.UtcNow,
                 Rate = 231.166079,
                 ExchangeRateToken = Guid.NewGuid().ToString()
             },
             new ExchangeRate
             {
                 BaseCurrencyCode = "USD",
                 DestinationCurrencyCode = "SGD",
                 IsActive = true,
                 ExchangeRateDate = DateTime.UtcNow,
                 Rate = 1.39439,
                 ExchangeRateToken = Guid.NewGuid().ToString()
             });
        _ = modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Code = "US",
                Name = "United States Of America",
                CurrencyCode = "USD",
                IsActive = true,
            },
            new Country
            {
                Code = "SE",
                Name = "Sweden",
                CurrencyCode = "SEK",
                IsActive = true,
            },
            new Country
            {
                Code = "SG",
                Name = "Singapore",
                CurrencyCode = "SGD",
                IsActive = true,
            },
            new Country
            {
                Code = "NO",
                Name = "Norway",
                CurrencyCode = "NOK",
                IsActive = true,
            },
            new Country
            {
                Code = "IN",
                Name = "India",
                CurrencyCode = "INR",
                IsActive = true,
            },
            new Country
            {
                Code = "AU",
                Name = "Australia",
                CurrencyCode = "AUD",
                IsActive = true,
            },
            new Country
            {
                Code = "PK",
                Name = "Pakistan",
                CurrencyCode = "PAK",
                IsActive = true,
            },
            new Country
            {
                Code = "UK",
                Name = "United Kingdom",
                CurrencyCode = "GBP",
                IsActive = true,
            });

        _ = modelBuilder.Entity<State>().HasData(
            new State
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
            },
            new State
            {
                Code = "NY",
                Name = "NewYork",
                CountryCode = "US",
            },
            new State
            {
                Code = "GE",
                Name = "Georgia",
                CountryCode = "US",
            },
            new State
            {
                Code = "SK",
                Name = "Stockholm",
                CountryCode = "SE",
            },
            new State
            {
                Code = "GT",
                Name = "Gothernberg",
                CountryCode = "SE",
            });

        _ = modelBuilder.Entity<TransferMode>().HasData(
            new TransferMode
            {
                TransferModeId = 1,
                TransferModeDescription = "Transfer money from bank",
                TransferModeName = "Bank",
            },
             new TransferMode
             {
                 TransferModeId = 2,
                 TransferModeDescription = "Credit card transfer",
                 TransferModeName = "Credit",
             },
              new TransferMode
              {
                  TransferModeId = 3,
                  TransferModeDescription = "Transfer money using RTGS",
                  TransferModeName = "Bank",
              },
               new TransferMode
               {
                   TransferModeId = 4,
                   TransferModeDescription = "Transfer money using trustly",
                   TransferModeName = "Trustly",
               });
        _ = modelBuilder.Entity<FeesDetails>().HasData
            (
                    new FeesDetails
                    {
                        FeesDetailsId = 1,
                        FeesPercentage = 0.6,
                        IsAvailable = true,
                        FromCountryCode = "US",
                        ToCountryCode = "SE",
                        TransferModeId = 1,
                    },
                    new FeesDetails
                    {
                        FeesDetailsId = 2,
                        FeesPercentage = 0.8,
                        IsAvailable = true,
                        FromCountryCode = "US",
                        ToCountryCode = "SE",
                        TransferModeId = 2,
                    },
                    new FeesDetails
                    {
                        FeesDetailsId = 3,
                        FeesPercentage = 0.9,
                        IsAvailable = true,
                        FromCountryCode = "US",
                        ToCountryCode = "SE",
                        TransferModeId = 3,
                    },
                    new FeesDetails
                    {
                        FeesDetailsId = 4,
                        FeesPercentage = 0.6,
                        IsAvailable = true,
                        FromCountryCode = "SE",
                        ToCountryCode = "US",
                        TransferModeId = 1,
                    },
                    new FeesDetails
                    {
                        FeesDetailsId = 5,
                        FeesPercentage = 0.8,
                        IsAvailable = true,
                        FromCountryCode = "SE",
                        ToCountryCode = "US",
                        TransferModeId = 2,
                    },
                    new FeesDetails
                    {
                        FeesDetailsId = 6,
                        FeesPercentage = 0.9,
                        IsAvailable = true,
                        FromCountryCode = "SE",
                        ToCountryCode = "US",
                        TransferModeId = 4,
                    }
                );
        _ = modelBuilder.Entity<Bank>().HasData(
            new Bank
            {
                AccountNumber = "12345578",
                BankName = "HSBC Bank of America",
                BankCode = "HSB",
                IFSCCode = "431011201",
                MICRCode = "43101120",
                CountryCode = "US",

            },
             new Bank
             {
                 AccountNumber = "12345578",
                 BankName = "Morgan Stanely",
                 BankCode = "MS",
                 IFSCCode = "431011201",
                 MICRCode = "43101120",
                 CountryCode = "US",
             },
              new Bank
              {
                  AccountNumber = "12345578",
                  BankName = "BankofAmerica",
                  BankCode = "BOA",
                  IFSCCode = "431011201",
                  MICRCode = "43101120",
                  CountryCode = "US",

              },
               new Bank
               {
                   AccountNumber = "1234558",
                   BankName = "Wells Fargo",
                   BankCode = "WF",
                   IFSCCode = "431011201",
                   MICRCode = "43101120",
                   CountryCode = "US",

               },
                new Bank
                {
                    AccountNumber = "12345578",
                    BankName = "Citigroup",
                    BankCode = "CG",
                    IFSCCode = "431011201",
                    MICRCode = "43101120",
                    CountryCode = "US",

                },
                 new Bank
                 {
                     AccountNumber = "12345578",
                     BankName = "Goldman Sachs",
                     BankCode = "GS",
                     IFSCCode = "431011201",
                     MICRCode = "43101120",
                     CountryCode = "US",

                 },
                new Bank
                {
                    AccountNumber = "12345578",
                    BankName = "BankofAmerica",
                    BankCode = "BOA",
                    IFSCCode = "431011201",
                    MICRCode = "43101120",
                    CountryCode = "SE",

                },
               new Bank
               {
                   AccountNumber = "1234558",
                   BankName = "Swed",
                   BankCode = "SWE",
                   IFSCCode = "431011201",
                   MICRCode = "43101120",
                   CountryCode = "SE",

               },
                new Bank
                {
                    AccountNumber = "12345578",
                    BankName = "SEB",
                    BankCode = "SEB",
                    IFSCCode = "431011201",
                    MICRCode = "43101120",
                    CountryCode = "SE",
                },
                 new Bank
                 {
                     AccountNumber = "12345578",
                     BankName = "Handelsbanken",
                     BankCode = "HB",
                     IFSCCode = "431011201",
                     MICRCode = "43101120",
                     CountryCode = "SE",
                 });
        _ = modelBuilder.Entity<Beneficiary>().HasData(
            new Beneficiary
            {
                AccountNumber = "123456789",
                BankCode = "BOA",
                BeneficiaryName = "Rajkumar"
            },
            new Beneficiary
            {
                AccountNumber = "12345",
                BankCode = "BOA",
                BeneficiaryName = "Johny"
            },
            new Beneficiary
            {
                AccountNumber = "12345",
                BankCode = "HSB",
                BeneficiaryName = "Robin"
            },
            new Beneficiary
            {
                AccountNumber = "123456789",
                BankCode = "HSB",
                BeneficiaryName = "Isebella"
            },
            new Beneficiary
            {
                AccountNumber = "123456789",
                BankCode = "WF",
                BeneficiaryName = "Jansi"
            });
    }

    public virtual DbSet<Country> Countries { get; set; }
    public virtual DbSet<State> States { get; set; }
    public virtual DbSet<Currency> Currencies { get; set; }
    public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    public virtual DbSet<TransferMode> TransferModes { get; set; }
    public virtual DbSet<FeesDetails> FeesDetails { get; set; }
    public virtual DbSet<Bank> Banks { get; set; }
    public virtual DbSet<Beneficiary> Beneficiaries { get; set; }
}

