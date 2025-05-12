using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrinciple
{
    public class DefaultAuthenticationProvider<T> : AuthenticationManager<T>
            where T : AuthenticationRequest
    {
        public override bool Authenticate(T request)
        {
            if(string.IsNullOrWhiteSpace(request.Username))
                throw new ArgumentNullException(nameof(request.Username));

            if (string.IsNullOrWhiteSpace(request.Password))
                throw new ArgumentNullException(nameof(request.Password));

            // Simulate authentication logic
            if (request.Username == "admin" && request.Password == "password")
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
