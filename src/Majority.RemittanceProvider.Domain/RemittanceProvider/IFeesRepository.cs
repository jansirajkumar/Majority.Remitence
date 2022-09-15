namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public interface IFeesRepository
    {
        /// <summary>
        /// This function is used to get the payment modes and the fees percentage for the source and destination country.
        /// </summary>
        /// <param name="sourceCountryCode"></param>
        /// <param name="destinationCountryCode"></param>
        /// <returns></returns>
        Task<List<FeesDetails>> GetFees(string sourceCountryCode, string destinationCountryCode);
    }
}
