using System.Text.RegularExpressions;

namespace ParcelManager
{
    public class ParcelService
    {
        public bool IsValidParcelNumber(string parcelNumber)
        {
            if(parcelNumber == null)
                throw new ArgumentNullException();

            if(parcelNumber.Trim().Length > 20)
                throw new InvalidOperationException("Parcel Number is too long");

            //1. Starts with BLR
            //2. Max of 6 characters
            //return parcelNumber.Trim().StartsWith("BLR",StringComparison.OrdinalIgnoreCase) && parcelNumber.Trim().Length == 6;
            var regEx = new Regex(@"^[A-Z]{3,3}[0-9]{3,3}$", RegexOptions.IgnoreCase);
            return regEx.IsMatch(parcelNumber.Trim());
        }
    }
}
