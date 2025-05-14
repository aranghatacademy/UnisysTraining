using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthBAsics
{
    public class DpapiUserManager
    {
        public DpapiUserManager() {

            var useCred = "admin:pass1234$$";
            byte[] bytes = Encoding.UTF8.GetBytes(useCred);

            // Encrypt the data
           byte[] encryptedData = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);
            File.WriteAllBytes("credentialsdapi.dat", encryptedData);
        }

        public bool Login(string userName, string password)
        {
            byte[] fileDAta = File.ReadAllBytes("credentialsdapi.dat");
            var decryptedData = ProtectedData.Unprotect(fileDAta, null, DataProtectionScope.CurrentUser);

            string credentials = Encoding.UTF8.GetString(decryptedData);
            var cred = credentials.Split(':');

            return cred[0] == userName && cred[1] == password;
        }

    }
}
