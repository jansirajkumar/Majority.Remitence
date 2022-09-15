using AutoMapper;
using Majority.RemittanceProvider.Application.Features.Commands;
using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Domain.RemittanceProvider;

namespace Majority.RemittanceProvider.Application.Transformers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TransactionCommand, TransactionSender>();
            CreateMap<TransactionCommand, TransactionTo>();
            CreateMap<TransactionCommand, Transaction>()
                .ForMember(x => x.Currency, options => options.MapFrom(src => src.FromCurrency))
                .ForMember(x => x.TransactionSender, options => options.MapFrom(src => src))
                .ForMember(x => x.TransactionTo, options => options.MapFrom(src => src));

            CreateMap<Country, CountryDto>();
            CreateMap<State, StateDto>();
            CreateMap<Bank, BankDto>()
                .ForMember(x => x.Code, options => options.MapFrom(src => src.BankCode))
                .ForMember(x => x.Name, options => options.MapFrom(src => src.BankName));
            CreateMap<Beneficiary, BeneficiaryDto>();



        }
    }
}
