namespace Majority.RemittanceProvider.Application.Features.Dtos
{
    public class FeesDto
    {
        public string FromCountryCode { get; set; }
        public string ToCountryCode { get; set; }
        public List<TransferModeDto> TransferMode { get; set; } = new List<TransferModeDto>();
    }

    public class TransferModeDto
    {
        public string TransferMode { get; set; }
        public string Description { get; set; }
        public double FeesInPercentage { get; set; }
    }
}
