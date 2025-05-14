using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CertificateAuth
{
    public static class CertAuthManager
    {
        public static bool Login()
        {
            X509Certificate2? cert = GetCertificate();

            return cert != null ? IsCertificateValid(cert) : false;
        }

        private static X509Certificate2? GetCertificate()
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);


            //We will serach for the certificate with a given name
            var certs = store.Certificates.Find(X509FindType.FindBySubjectName
                , "AranghatTech", false);
            var cert = certs.Count > 0 ? certs[0] : null;

            store.Close();
            return cert;
        }

        static  bool IsCertificateValid(X509Certificate2 cert)
        {
            // Check if the certificate is valid
            if (cert == null)
            {
                return false;
            }
       
            if(cert.NotAfter < DateTime.Now)
            {
                return false;
            }

            // Check if the certificate is issued by a trusted authority
            if (!cert.Subject.Contains("CN=AranghatTech"))
            {
                return false;
            }

            foreach (var ext in cert.Extensions)
            {
                if(ext.Oid.Value == "2.5.29.17")
                {
                    var rawData = ext.RawData;
                    var text = Encoding.UTF8.GetString(rawData);
                    if(!text.Contains("cert.aranghatech.com"))
                    {
                        return false;
                    }
                }
            }

            return true;
        }   
    
        public static string Encrypt(string data)
        {
            var cert = GetCertificate();

            if (cert == null)
                throw new InvalidOperationException();

            var dataBytes = Encoding.UTF8.GetBytes(data);
            var rsaPrivateKey = cert.GetRSAPublicKey();

            var encryptedData = rsaPrivateKey.Encrypt(dataBytes
                        , RSAEncryptionPadding.OaepSHA256);
            var encStr = Convert.ToBase64String(encryptedData);

            return encStr;

        }

        public static string Decrypt(string encData)
        {
            var cert = GetCertificate();

            var rsa = cert.GetRSAPrivateKey();

            byte[] decryptData = rsa.Decrypt(Convert.FromBase64String(encData)
                            , RSAEncryptionPadding.OaepSHA256);

            var decryptedString = Encoding.UTF8.GetString(decryptData);
            return decryptedString;
        }
    }
}
