
namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public interface ITransactionRepository
    {
        /// <summary>
        /// This function is used to get the transaction details based on transaction Id
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        Task<Transaction?> GetTransaction(Guid transactionId);

        /// <summary>
        /// Submit transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Task AddTransaction(Transaction transaction);
    }
}
