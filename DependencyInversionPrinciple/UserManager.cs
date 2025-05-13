using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    public class UserManager
    {
        private readonly IEmailService _emailService;

        public UserManager(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void Register(string username, string password)
        {
            // Registration logic
            Console.WriteLine($"User {username} registered with password {password}");

            // Send email notification
            //This is using a abstraction insted of concret implementation
            _emailService.SentEmail("Welcome to our application", username);
        }
    }
}
