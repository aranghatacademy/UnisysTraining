using System.Text.RegularExpressions;

namespace ParcelManager
{
    public class ParcelService
    {
        private IParcelRepository _parcelRepository;
        private EmailService _emailService;

        public ParcelService(IParcelRepository parcelRepository, EmailService emailService)
        {
            _parcelRepository = parcelRepository;
            _emailService = emailService;
        }

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

        public bool MarkParcelAsDelivered(string parcelNumber)
        {
            //1. The parcel number exist which results in UpdateParcelStatus returning true
            //2. The parcel number does not exist and the UpdateParcelStatus throws key not found exception
            try
            {
                var updateStatus = _parcelRepository.UpdateParcelStatus(parcelNumber, "Delivered");

                //Sent a email
                _emailService.SentEmail("customer@test.com", "Your parcel is delivered");

                return updateStatus;
            }
            catch(Exception excp)
            {
                return false;
            }
            
        }

        public Dictionary<string, string> GetParcels()
        {
            return _parcelRepository.GetParcels();
        }
    }
}
