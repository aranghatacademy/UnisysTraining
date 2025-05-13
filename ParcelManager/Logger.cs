using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelManager
{
    [ExcludeFromCodeCoverage]
    public class Logger
    {
        public void Log(string message)
        {
            // Log the message to a file or console
            Console.WriteLine(message);
        }
    }
}
