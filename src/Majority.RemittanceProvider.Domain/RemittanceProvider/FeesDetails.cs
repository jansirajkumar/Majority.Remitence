namespace Majority.RemittanceProvider.Domain.RemittanceProvider
{
    public class FeesDetails
    {
        public int FeesDetailsId { get; set; }
        public int TransferModeId { get; set; }
        public string FromCountryCode { get; set; }
        public string ToCountryCode { get; set; }
        public double FeesPercentage { get; set; }
        public bool IsAvailable { get; set; }
        public virtual TransferMode TransferMode { get; set; }
    }
}
