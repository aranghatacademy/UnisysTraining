using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelManager
{
    public interface IParcelRepository
    {
        public bool UpdateParcelStatus(string parcelNumber, string status);
        public Dictionary<string, string> GetParcels();
    }

    public class ParcelRepository : IParcelRepository
    {
        private Dictionary<string,string> _parcels;
        public ParcelRepository()
        {
            _parcels = new Dictionary<string, string>();
        }
        public bool UpdateParcelStatus(string parcelNumber, string status)
        {
            // Simulate updating the parcel status
            // In a real application, this would involve updating a database or some other data store
            if (_parcels.ContainsKey(parcelNumber))
            {
                _parcels[parcelNumber] = status;
                return true;
            }

            throw new KeyNotFoundException();
        }
        public Dictionary<string, string> GetParcels()
        {
            return _parcels;
        }
    }
}
