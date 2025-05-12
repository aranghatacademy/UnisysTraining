namespace OpenClosePrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var defaultAuthProvider = new
                DefaultAuthenticationProvider<AuthenticationRequest>();
            var defaultREquest = new AuthenticationRequest
            {
                Username = "admin",
                Password = "password"
            };

            defaultAuthProvider.Authenticate(defaultREquest);

            var twoFactorAuthProvider = new
                TwoFactorAuthenticationProvider<TwoFactorAuthenticationRequest>();
            var twoFactorRequest = new TwoFactorAuthenticationRequest
            {
                Username = "admin",
                Password = "password",
                OTP = "123456"
            };

            twoFactorAuthProvider.Authenticate(twoFactorRequest);
        }
    }
}
