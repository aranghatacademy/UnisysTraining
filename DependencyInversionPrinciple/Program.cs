namespace DependencyInversionPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emailProvider = EmailProviderFactory.CreateEmailService();

            //Usermanager does not know about the concrete implementation of the email service
            var userManager   = new UserManager(emailProvider);
            userManager.Register("sreehariis@gmail.com", "abcd@1234");

        }
    }
}
