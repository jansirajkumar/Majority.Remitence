namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public interface IBankRepository
    {
        /// <summary>
        /// This funciton is used to get the bank details
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        Task<List<Bank>> GetBankDetailsByCountryCode(string countryCode);
    }
}
