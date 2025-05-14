using System.Security.Claims;
using System.Security.Principal;
using AuthBAsics;

namespace Autharization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var isValidUser = new PasswordVaultCredentialManager().Login("admin", "pass1234$$");

            /*
                admin
                    -> CreateUser
                    -> ChangePassword
                    -> ChangePaymentGateway
             */

           if(isValidUser)
            {
               
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim("Permission","CreateUser"),
                    new Claim("Permission","ChangePassword"),
                    new Claim("Permission","ChangePaymentGateway")
                };

                var identity = new ClaimsIdentity(new GenericIdentity("Admin"),claims);
                var principal = new ClaimsPrincipal(identity);
                
            }
        }
    }
}
