using FluentValidation;
using Majority.RemittanceProvider.Application.Features.Queries;
using Majority.RemittanceProvider.Application.Features.Validators;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Majority.RemittanceProvider.Application.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(GetExchangeRatesQuery).Assembly);
        services.AddAutoMapper(typeof(Transformers.MappingProfile), typeof(Transformers.MappingProfile));
        services.AddValidatorsFromAssembly(typeof(ExchangeRateQueryValidator).Assembly);
        return services;
    }
}
