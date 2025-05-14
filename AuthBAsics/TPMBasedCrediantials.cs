using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AuthBAsics
{
   /* public class TPMBasedCrediantials
    {
        public TPMBasedCrediantials() {

           
        }

        public async Task CreateCredentials()
        {
            var userCred = "admin:pass1234$$";
            var descriptor = "SID=S-1-5-21-3293373812-2299869004-3931475193-1000;TPM";

            IBuffer buffer = CryptographicBuffer.ConvertStringToBinary(userCred, BinaryStringEncoding.Utf8);

            var provider = new DataProtectionProvider(descriptor);
            IBuffer protectedBuffer = await provider.ProtectAsync(buffer);

            var storageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("credentialstpm.dat"
                                                                , CreationCollisionOption.ReplaceExisting);



            await FileIO.WriteBufferAsync(storageFile, protectedBuffer);
        }

        public async Task<bool> Login(string username, string password)
        {
            var descriptor = "SID=S-1-5-21-3293373812-2299869004-3931475193-1000;TPM";
            var storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync("credentialstpm.dat");
            IBuffer protectedBuffer = await FileIO.ReadBufferAsync(storageFile);


            var provider = new DataProtectionProvider(descriptor);
            IBuffer unprotectedBuffer = await provider.UnprotectAsync(protectedBuffer);
            string credentials = CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, unprotectedBuffer);


            var cred = credentials.Split(':');
            return cred[0] == username && cred[1] == password;
        }
    }*/
}
