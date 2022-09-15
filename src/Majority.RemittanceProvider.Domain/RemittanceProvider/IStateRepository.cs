namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public interface IStateRepository
    {
        Task<List<State>> GetStates(string countryCode = "US");
    }
}
