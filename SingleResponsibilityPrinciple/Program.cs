using SingleResponsibilityPrinciple.Model;

namespace SingleResponsibilityPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userManager = new UserManager();
            userManager.NewRegistrationEvent += SentWelcomeEmailHandler;
            userManager.NewRegistrationEvent += SentVerifyEmailHandler;
            userManager.NewRegistrationEvent += UpdateCRMForDemoHandler;

            var newUserRequest = new RegisterRequest { Email = "jhon@test.com", Name = "Jhon", Password = "abcd@1234" };
            userManager.Register(newUserRequest);
        }

        public static void SentWelcomeEmailHandler(object sender, NewRegistrationEvent e)
        {
            Console.WriteLine($"Sending welcome email to {e.Name} at {e.Email}");
        }

        public static void SentVerifyEmailHandler(object sender, NewRegistrationEvent e)
        {
            Console.WriteLine($"Sending verify email to {e.Name} at {e.Email}");
        }

        public static void UpdateCRMForDemoHandler(object sender, NewRegistrationEvent e)
        {
            Console.WriteLine($"Updating CRM for {e.Name} at {e.Email}");
        }
    }
}
