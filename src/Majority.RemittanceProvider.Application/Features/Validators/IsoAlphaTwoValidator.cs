using System.Globalization;

namespace Majority.RemittanceProvider.Application.Features.Validators
{
    public static class IsoAlphaTwoValidator
    {
        public static bool IsoAlphaValidator(string isoAlphaTwo)
        {
            RegionInfo isoRegionInfo = new RegionInfo(isoAlphaTwo);
            return isoRegionInfo.DisplayName != string.Empty;
        }

    }
}
