using System.Security.Cryptography.X509Certificates;

namespace CertificateAuth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*var certPath = @"c:\certs\client.pfx";
            var cert = new X509Certificate2(certPath, "password");

           /* Console.WriteLine(@$"Certificate 
                {cert.Subject}
                    {cert.Issuer}
{cert.FriendlyName}
{cert.GetNameInfo(X509NameType.SimpleName, false)}
");


            if(cert.Subject == "CN=Aranghat" && cert.Issuer == "aranghattech.com")
            {

            }
            else
            {
                Console.WriteLine("Invalid certificate");
            }*/


            var isLogedIn = CertAuthManager.Login();

            if (isLogedIn)
            {
                Console.WriteLine("Login successful");
                var dataToEncrypt = "Hello World";
                var encryptedData = CertAuthManager.Encrypt(dataToEncrypt);

                Console.WriteLine($"Encrypted data: {encryptedData}");

                Console.WriteLine("-----------------------------------------");

                Console.WriteLine($"Decrypted data: {CertAuthManager.Decrypt(encryptedData)}");
            }
            else
                Console.WriteLine("Login failed");
        }
    }
}
