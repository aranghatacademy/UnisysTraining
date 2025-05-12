using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrinciple
{
    public class TwoFactorAuthenticationRequest : AuthenticationRequest
    {
        [Required]
        public string OTP { get; set; }
    }

    public class TwoFactorAuthenticationProvider<T> : DefaultAuthenticationProvider<T>
            where T : TwoFactorAuthenticationRequest
    {
        public override bool Authenticate(T request)
        {
            //Exising logic is kept as it is
            var checkPasswordIsValid = base.Authenticate(request);
            var isOtpValid =  request.OTP == "123456"; // Simulate OTP validation

            if(checkPasswordIsValid && isOtpValid)
            {
                return true;
            }
            else
            {
                throw new AuthenticationException("Invalid OTP.");
            }
        }
    }
}
