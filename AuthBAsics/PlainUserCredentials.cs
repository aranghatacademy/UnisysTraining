using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AuthBAsics
{
    public  class PlainUserCredentials
    {
        public PlainUserCredentials()
        {
            var userCredentials          = "admin:pass1234$$";
            var base64EncodedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(userCredentials));
            File.WriteAllText("credentials.data", base64EncodedCredentials);
        }

        public bool Login(string userName, string password)
        {
            var base64EncodedCredentials = File.ReadAllText("credentials.data");
            var decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedCredentials));

            var credentials = decodedCredentials.Split(':');
            return credentials[0] == userName && credentials[1] == password;
        }
    }
}
