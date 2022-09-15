namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public interface IBeneficiaryRepository
    {
        /// <summary>
        /// This function is used to get the beneficiary details
        /// </summary>
        /// <param name="bankCode"></param>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        Task<Beneficiary> GetBeneficiaryDetailsByBankCodeAndAccountNumber(string bankCode, string accountNumber);
    }
}
