using AutoMapper;
using Majority.RemittanceProvider.Application.Features.Dtos;
using Majority.RemittanceProvider.Domain.RemittanceProvider;
using MediatR;

namespace Majority.RemittanceProvider.Application.Features.Queries
{
    public class GetStatesQueryHandler : IRequestHandler<GetStatesQuery, List<StateDto>>
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        public GetStatesQueryHandler(IStateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }
        public async Task<List<StateDto>> Handle(GetStatesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var states = await _stateRepository.GetStates(request.CountryCode);
                if (states?.Count > 0)
                {
                    return _mapper.Map<List<StateDto>>(states);
                }
                throw new ArgumentException("No states found");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
