using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelManager
{
    public class EmailService
    {
        public virtual void SentEmail(string  email, string message)
        {
            Console.WriteLine($"Email sent to {email} with message: {message}");
        }
    }
}
