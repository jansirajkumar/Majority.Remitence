using Majority.RemittanceProvider.Domain.RemittanceProvider;
using Majority.RemittanceProvider.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Majority.RemittanceProvider.Infrastructure.Extensions;
public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RemittanceProviderContext>
                (item => item.UseSqlServer(configuration.GetConnectionString("RemittanceProvider")));
        services.AddScoped<IExchangeRateRepository, ExchangeRateRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IStateRepository, StateRepository>();
        services.AddScoped<IFeesRepository, FeesRepository>();
        services.AddScoped<IBankRepository, BankRepository>();
        services.AddScoped<IBeneficiaryRepository, BeneficiaryRepository>();
        return services;
    }


}



