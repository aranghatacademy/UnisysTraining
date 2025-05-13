using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    public interface IEmailService
    {
        void SentEmail(string message, string to);
    }

    public class SentGridEmailService : IEmailService
    {
        public void SentEmail(string message,string to)
        {
            Console.WriteLine("Send Grid and sent the email");
        }
    }

    public class AzureEmailService : IEmailService
    {
        public void SentEmail(string message, string to)
        {
            Console.WriteLine("Azure and sent the email");
        }
    }
}
