using System.Security.Principal;

namespace AuthBAsics
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //1. User Name and Password
            //2. Windows User
            //3. Certificates
            //4. Tokens

            //var planUserCredentials = new PlainUserCredentials();
            /*var dapiCredManager = new DpapiUserManager();
            var userName = "admin";
            var password = "pass1234$$";

            if (dapiCredManager.Login(userName, password))
            {
                Console.WriteLine("Login successful");
            }
            else
            {
                Console.WriteLine("Login failed");
            }*/

            /*var tpmBasedCred = new TPMBasedCrediantials();
            await tpmBasedCred.CreateCredentials();

            var userName = "admin";
            var password = "pass1234$$";

            if (await tpmBasedCred.Login(userName, password))
            {
                Console.WriteLine("Login successful");
            }
            else
            {
                Console.WriteLine("Login failed");
            }

            var plainUserCredentials = new PasswordVaultCredentialManager();
            var isLogedIn = plainUserCredentials.Login("admin", "pass1234$$");

            if (isLogedIn)
            {
                Console.WriteLine("Login successful");
            }
            else
            {
                Console.WriteLine("Login failed");
            }*/


            //User under with you are running the application
             var canAccessApplication = new WindowsAuthManager().Login();

            if(canAccessApplication)
            {
                Console.WriteLine("Login successful");
            }
            else
            {
                Console.WriteLine("You do not have permission to run this application");
            }
        }
    }
}
