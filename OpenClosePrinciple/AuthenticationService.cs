using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrinciple
{
    public class AuthenticationService
    {
        public bool Authenticate(string username, string password)
        {
           if(string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException(nameof(username));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            // Simulate authentication logic
            if (username == "admin" && password == "password")
            {
                return true;
            }
            else
            {
                throw new AuthenticationException("Invalid username or password.");
            }
        }
    }
}
