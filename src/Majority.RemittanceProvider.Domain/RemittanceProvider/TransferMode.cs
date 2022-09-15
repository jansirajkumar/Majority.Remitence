
namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public class TransferMode
    {
        public int TransferModeId { get; set; }
        public string TransferModeName { get; set; }
        public string TransferModeDescription { get; set; }
        public virtual List<FeesDetails> Fees { get; set; }
    }
}
