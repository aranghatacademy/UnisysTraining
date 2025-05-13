using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    public static class EmailProviderFactory
    {
        public static IEmailService CreateEmailService(string provider = "sendgrid")
        {
            switch (provider.ToLower())
            {
                case "sendgrid":
                    return new SentGridEmailService();
                case "azure":
                    return new AzureEmailService();
                default:
                    throw new ArgumentException("Invalid email provider");
            }
        }
    }
}
