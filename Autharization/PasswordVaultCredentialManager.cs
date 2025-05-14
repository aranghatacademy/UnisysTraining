using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredentialManagement;

namespace AuthBAsics
{
    public class PasswordVaultCredentialManager
    {
        
        public PasswordVaultCredentialManager() {

            var cred = new Credential
            {
                Target = "MyPasswordService",
                Username = "admin",
                Password = "pass1234$$",
                Type = CredentialType.Generic,
                PersistanceType = PersistanceType.LocalComputer,
              

            };

            cred.Save();
        }

        public bool Login(string username,string password)
        {
            var cred = new Credential
            {
                Target = "MyPasswordService"
            };

            if(cred.Load())
            {
                return cred.Username == username && cred.Password == password;
            }

            return false;
        }

      
    }
}
